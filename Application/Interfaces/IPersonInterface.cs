using Application.DTO_s.Person;
using Application.DTO_s;
using Core.Models;
using Core.Enums;
using Application.Paging;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IPersonInterface
    {
        Task<int> CreatePerson(PersonDTO personDTO);
        Task<string?> UploadPersonImage(int personId, IFormFile imageFile);
        Task<GetPersonDTO> GetPerson(int id);
        Task<Person> DeletePerson(int id);
        Task<int> UpdatePerson(UpdatePersonDTO person);
        Task<GetPersonDTO> GetPersonsQuickSearch(string firstName, string lastName,string personalNumber);
        Task<GetPersonDTO> GetPersonByDetailedSearch(GetPersonDTO getPersonDTO);
        Task<PagedList<Person>> GetPersonsByPaging( int pageNumber, int pageSize);
        Task<int> GetConnectedPersonsCount(int personId, ConnectionType connectionType);

    }
}
