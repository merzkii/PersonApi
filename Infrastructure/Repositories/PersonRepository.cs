using Application.DTO_s;
using Application.DTO_s.Person;
using Application.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class PersonRepository : IPersonInterface
    {
        public Task<int> CreatePerson(PersonDTO personDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Person> DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Person>> GetPersons()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePerson(UpdatePersonDTO person)
        {
            throw new NotImplementedException();
        }
    }
}
