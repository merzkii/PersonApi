using Application.DTO_s;
using Application.DTO_s.Person;
using Application.Interfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Layer;
using Microsoft.EntityFrameworkCore;

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
            var person = await GetPerson(id);
            if (person == null)
                throw new NullReferenceException("Person not found");
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return person;

        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await _context.Persons.SingleAsync(p => p.Id == id);
            if (person == null)
            {
                throw new NullReferenceException("Person not found");
            }
            return person;
        }

        public async Task<ICollection<Person>> GetPersons()
        {
            var persons=await _context.Persons.OrderBy(p=>p.Id).ToListAsync();
            return persons;
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
    }
}
