using Application.DTO_s.Person;
using Application.DTO_s;
using Core.Models;
using Core.Enums;
using Application.Paging;

namespace Application.Interfaces
{
    public interface IPersonInterface
    {
        Task<int> CreatePerson(PersonDTO personDTO);
        Task<GetPersonDTO> GetPerson(int id);
        Task<Person> DeletePerson(int id);
        Task<int> UpdatePerson(UpdatePersonDTO person);
        Task<GetPersonDTO> GetPersonsQuickSearch(string firstName, string lastName,string personalNumber);
        Task<PagedList<Person>> GetPersonsByPaging( int pageNumber, int pageSize);
        Task<int> GetConnectedPersonsCount(int personId, ConnectionType connectionType);

    }
}
