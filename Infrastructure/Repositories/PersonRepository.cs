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
            var person = mapper.Map<Person>(updatePersonDTO);
            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
        

        public async Task<PagedList<Person>> GetPersonsByPaging(int pageNumber, int pageSize)
        {
            var query = _context.Persons.AsQueryable();

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
        public async Task<GetPersonDTO> GetPersonsQuickSearch (string firstName, string lastName, string personalNumber)
        {
            var person = await _context.Persons
                .Include(p => p.City)
                .Include(p => p.PhoneNumbers)
                .ThenInclude(sp => sp.Phone)
                .Include(p => p.RelatedIndividuals)
                .ThenInclude(cp => cp.RelatedPerson)
                .SingleOrDefaultAsync(p => p.FirstName == firstName && p.LastName == lastName && p.PersonalNumber == personalNumber);

            if (person == null)
            {
                throw new NullReferenceException("Person not found");
            }
            return person.CreateDTO();
        }

        public async Task<GetPersonDTO> GetPersonByDetailedSearch(GetPersonDTO getPersonDTO)
        {
            var person = await _context.Persons
                .Include(p => p.City)
                .Include(p => p.PhoneNumbers)
                .ThenInclude(sp => sp.Phone)
                .Include(p => p.RelatedIndividuals)
                .ThenInclude(cp => cp.RelatedPerson)
                .SingleOrDefaultAsync(p => p.FirstName == getPersonDTO.FirstName
                                           && p.LastName == getPersonDTO.LastName
                                           && p.PersonalNumber == getPersonDTO.PersonalNumber
                                           && p.Gender == getPersonDTO.Gender
                                           && p.DateOfBirth == getPersonDTO.DateOfBirth
                                           && p.CityId == getPersonDTO.cityId);

            if (person == null)
            {
                throw new NullReferenceException("Person not found");
            }
            return person.CreateDTO();
        }


    }

}
