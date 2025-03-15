using Application.DTO_s;
using Application.DTO_s.Person;
using Application.DTO_s.Phone;
using Application.Extensions;
using Application.Interfaces;
using Application.Paging;
using AutoMapper;
using Core.Enums;
using Core.Models;
using Infrastructure.Layer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonInterface
    {
        private readonly DataContext _context;
        private readonly IMapper mapper;
        public PersonRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<int> CreatePerson(PersonDTO personDTO)
        {
            var person = mapper.Map<Person>(personDTO);
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }

        public async Task<Person> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                throw new NullReferenceException($"Person not found On {id}-Id");
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<GetPersonDTO> GetPerson(int id)
        {
            var person = await _context.Persons
                .Include(p => p.City)
                .Include(p => p.PhoneNumbers)
                .ThenInclude(sp => sp.Phone)
                .Include(p => p.RelatedIndividuals)
                .ThenInclude(cp => cp.RelatedPerson)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                throw new NullReferenceException("Person not found");
            }
            return person.CreateDTO();
        }


       



        public async Task<int> UpdatePerson(UpdatePersonDTO updatePersonDTO)
        {
            var existingPerson = await GetPerson(updatePersonDTO.Id);
            if (existingPerson == null)
                throw new NullReferenceException("Person not found");
           var person= mapper.Map<Person>(updatePersonDTO);
            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }

        public async Task<(ICollection<Person>, int)> GetPersonsQuickSearch(string searchTerm, int pageNumber, int pageSize)
        {
            var query = _context.Persons.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.FirstName.Contains(searchTerm) ||
                                         p.LastName.Contains(searchTerm) ||
                                         p.PersonalNumber.Contains(searchTerm));
            }

            var totalRecords = await query.CountAsync();
            var persons = await query.Include(p => p.City)
                                     .Include(p => p.PhoneNumbers)
                                     .ThenInclude(sp => sp.Phone)
                                     .Include(p => p.RelatedIndividuals)
                                     .ThenInclude(cp => cp.RelatedPerson)
                                     .OrderBy(p => p.Id)
                                     .Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();

            return (persons, totalRecords);
        }

        public async Task<PagedList<Person>> GetPersonsDetailedSearch( int pageNumber, int pageSize)
        {
            var query = _context.Persons.AsQueryable();

            //if (!string.IsNullOrEmpty(searchCriteria.FirstName))
            //{
            //    query = query.Where(p => p.FirstName.Contains(searchCriteria.FirstName));
            //}
            //if (!string.IsNullOrEmpty(searchCriteria.LastName))
            //{
            //    query = query.Where(p => p.LastName.Contains(searchCriteria.LastName));
            //}
            //if (!string.IsNullOrEmpty(searchCriteria.PersonalNumber))
            //{
            //    query = query.Where(p => p.PersonalNumber.Contains(searchCriteria.PersonalNumber));
            //}
            //if (searchCriteria.Gender != null)
            //{
            //    query = query.Where(p => p.Gender == searchCriteria.Gender);
            //}
            //if (searchCriteria.DateOfBirth != DateTime.MinValue)
            //{
            //    query = query.Where(p => p.DateOfBirth == searchCriteria.DateOfBirth);
            //}
            //if (searchCriteria.cityId != 0)
            //{
            //    query = query.Where(p => p.CityId == searchCriteria.cityId);
            //}

            var totalRecords = await query.CountAsync();
            var persons = await query.Include(p => p.City)
                                     .Include(p => p.PhoneNumbers)
                                     .ThenInclude(sp => sp.Phone)
                                     .Include(p => p.RelatedIndividuals)
                                     .ThenInclude(cp => cp.RelatedPerson)
                                     .OrderBy(p => p.Id)
                                     .Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();

            return new PagedList<Person>(persons, totalRecords);
        }

        public async Task<int> GetConnectedPersonsCount(int personId, ConnectionType connectionType)
        {
            var count = await _context.ConnectedPersons
                .Where(cp => cp.PersonId == personId && cp.ConnectionType == connectionType)
                .CountAsync();

            return count;
        }
        
       
    }

}
