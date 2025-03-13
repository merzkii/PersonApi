using Application.DTO_s.Person;
using Core.Models;

namespace Application.Interfaces
{
    public interface IConnectedPersonInterface
    {
        Task<ICollection<ConnectedPerson>> GetConnectedPersons();
        Task<int> CreateConnectedPersons(ConnectedPersonDTO id);
        Task<ConnectedPerson> GetConnectedPerson(int id);
        Task<ConnectedPerson> DeleteConnectedPerson(int id);
        Task<int> UpdateConnectedPerson(UpdateConnectedPersonDTO updateconnectedPerson);
    }
}
