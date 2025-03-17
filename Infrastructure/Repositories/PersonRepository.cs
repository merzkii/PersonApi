﻿using Application.DTO_s;
using Application.DTO_s.Person;
using Application.Extensions;
using Application.Interfaces;
using Application.Paging;
using AutoMapper;
using Core.Enums;
using Core.Models;
using Infrastructure.Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonInterface
    {
        private readonly DataContext _context;
        private readonly IImageService _imageService;
        private readonly IMapper mapper;
        public PersonRepository(DataContext context, IMapper mapper, IImageService imageService)
        {
            _context = context;
            this.mapper = mapper;
            _imageService = imageService;
        }
        public async Task<int> CreatePerson(PersonDTO personDTO)
        {
            var existingPesron = await _context.Persons.SingleOrDefaultAsync(p => p.PersonalNumber == personDTO.PersonalNumber);
            if (existingPesron != null)
            {
                throw new InvalidOperationException($"Person with personal number {personDTO.PersonalNumber} already exists.");
            }
            var person = mapper.Map<Person>(personDTO);
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }

        public async Task<int> DeletePerson(int id)
        {
            try
            {
                var person = await _context.Persons.FindAsync(id);
                if (person == null)
                    throw new NullReferenceException($"Person not found On {id}-Id");
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                return person.Id;
            }
            catch
            {
                throw new InvalidOperationException("Person can not be deleted because it is connected to other records.");
            }
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
            mapper.Map<GetPersonDTO>(person);
            return person.CreateDTO();
        }

        public async Task<int> UpdatePerson(UpdatePersonDTO updatePersonDTO)
        {
            var existingPerson = await _context.Persons.FindAsync(updatePersonDTO.Id);
            if (existingPerson == null)
                throw new NullReferenceException("Person not found");
            if (existingPerson.PersonalNumber != updatePersonDTO.PersonalNumber)
            {
                var existingPesron = await _context.Persons.SingleOrDefaultAsync(p => p.PersonalNumber == updatePersonDTO.PersonalNumber);
                if (existingPesron != null)
                {
                    throw new InvalidOperationException($"Person with personal number {updatePersonDTO.PersonalNumber} already exists.");
                }
            }
            var person = mapper.Map<Person>(updatePersonDTO);
            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }


        public async Task<PagedList<GetPersonDTO>> GetPersonsByPaging(int pageNumber, int pageSize)
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
            if (persons == null)
            {
                throw new NullReferenceException("Records not found");
            }

            return new PagedList<GetPersonDTO>(persons.Select(p => p.CreateDTO()).ToList(), totalRecords);
        }

        public async Task<int> GetConnectedPersonsCount(int personId, ConnectionType connectionType)
        {
            var count = await _context.ConnectedPersons
                .Where(cp => cp.PersonId == personId && cp.ConnectionType == connectionType)
                .CountAsync();
            if (count == 0)
            {
                throw new NullReferenceException("Connections not found");
            }
            return count;
        }
        public async Task<List<GetPersonDTO>> GetPersonsQuickSearch(string? firstName, string? lastName, string? personalNumber)
        {
            var persons = await _context.Persons
                .Include(p => p.City)
                .Include(p => p.PhoneNumbers)
                .ThenInclude(sp => sp.Phone)
                .Include(p => p.RelatedIndividuals)
                .ThenInclude(cp => cp.RelatedPerson)
.Where(p => (firstName == null || p.FirstName == firstName)
&& (lastName == null || p.LastName == lastName)
&& (personalNumber == null || p.PersonalNumber == personalNumber)).ToListAsync();

            if (persons == null)
            {
                throw new NullReferenceException("Person not found");
            }
            return persons.Select(p => p.CreateDTO()).ToList();
        }

        //public async Task<GetPersonDTO> GetPersonByDetailedSearch(GetPersonDTO getPersonDTO)
        //{
        //    var person = await _context.Persons
        //        .Include(p => p.City)
        //        .Include(p => p.PhoneNumbers)
        //        .ThenInclude(sp => sp.Phone)
        //        .Include(p => p.RelatedIndividuals)
        //        .ThenInclude(cp => cp.RelatedPerson)
        //        .SingleOrDefaultAsync(p => p.FirstName == getPersonDTO.FirstName
        //                                   && p.LastName == getPersonDTO.LastName
        //                                   && p.PersonalNumber == getPersonDTO.PersonalNumber
        //                                   && p.Gender == getPersonDTO.Gender
        //                                   && p.DateOfBirth == getPersonDTO.DateOfBirth
        //                                   && p.CityId == getPersonDTO.cityId);

        //    if (person == null)
        //    {
        //        throw new NullReferenceException("Person not found");
        //    }
        //    return person.CreateDTO();
        //}

        public async Task<string?> UploadPersonImage(int personId, IFormFile imageFile)
        {
            var person = await _context.Persons.FindAsync(personId);
            if (person == null)
                throw new NullReferenceException("Person not found");

            string imagePath = await _imageService.SaveImageAsync(imageFile);
            person.ImagePath = imagePath;

            await _context.SaveChangesAsync();
            return imagePath;
        }


    }

}
