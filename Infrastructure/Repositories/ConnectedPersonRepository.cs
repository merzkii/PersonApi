using Application.DTO_s.Person;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public class ConnectedPersonRepository : IConnectedPersonInterface
    {
        public Task<int> CreateConnectedPersons(ConnectedPersonDTO id)
        {
            throw new NotImplementedException();
        }

        public Task<ConnectedPerson> DeleteConnectedPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ConnectedPerson> GetConnectedPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ConnectedPerson>> GetConnectedPersons()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateConnectedPerson(UpdateConnectedPersonDTO updateconnectedPerson)
        {
            throw new NotImplementedException();
        }
    }
}
