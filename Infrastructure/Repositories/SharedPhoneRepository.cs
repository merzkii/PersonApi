using Application.DTO_s.Phone;
using Application.Interfaces;
using Core.Models;

namespace PersonApi
{
    public class SharedPhoneRepository : ISharedPhoneInterface
    {
        public Task<int> Create2phones(SharedPhoneDTO id)
        {
            throw new NotImplementedException();
        }

        public Task<SharedPhone> Delete2Persons(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SharedPhone> GetPhone2Person(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SharedPhone>> GetPhone2Persons()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePhone2Person(UpdateSharedPhoneDTO updateperson2PhonesDTO)
        {
            throw new NotImplementedException();
        }
    }
}
