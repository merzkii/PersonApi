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
        Task<(ICollection<Person>, int)> GetPersonsQuickSearch(string searchTerm, int pageNumber, int pageSize);
        Task<PagedList<Person>> GetPersonsDetailedSearch( int pageNumber, int pageSize);
        Task<int> GetConnectedPersonsCount(int personId, ConnectionType connectionType);

    }
}
