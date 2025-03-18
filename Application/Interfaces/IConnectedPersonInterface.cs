using Application.DTO_s.Person;
using Core.Models;

namespace Application.Interfaces
{
    public interface IConnectedPersonInterface
    {
        Task<List<GetConnectedPersonsDTO>> GetConnections();
        Task<int> CreateConnections(ConnectedPersonDTO id);
        Task<GetConnectedPersonsDTO> GetConnection(int id);
        Task<int> DeleteConnection(int id);
        //Task<int> UpdateConnectedPerson(UpdateConnectedPersonDTO updateconnectedPerson);
    }
}
