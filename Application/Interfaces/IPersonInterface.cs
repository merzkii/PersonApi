using Application.DTO_s.Person;
using Application.DTO_s;
using Core.Models;

namespace Application.Interfaces
{
    public interface IPersonInterface
    {
        Task<ICollection<Person>> GetPersons();
        Task<int> CreatePerson(PersonDTO personDTO);
        Task<Person> GetPerson(int id);
        Task<Person> DeletePerson(int id);
        Task<int> UpdatePerson(UpdatePersonDTO person);

    }
}
