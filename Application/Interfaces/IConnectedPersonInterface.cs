using Application.DTO_s.Person;
using Core.Models;

namespace Application.Interfaces
{
    public interface IConnectedPersonInterface
    {
        Task<List<GetConnectedPersonsDTO>> GetConnectedPersons();
        Task<int> CreateConnectedPersons(ConnectedPersonDTO id);
        Task<GetConnectedPersonsDTO> GetConnectedPerson(int id);
        Task<int> DeleteConnectedPerson(int id);
        Task<int> UpdateConnectedPerson(UpdateConnectedPersonDTO updateconnectedPerson);
    }
}
