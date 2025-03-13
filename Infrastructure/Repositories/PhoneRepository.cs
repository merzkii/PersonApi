using Application.DTO_s.Phone;
using Application.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PhoneRepository : IPhoneInterface
    {
        public Task<int> CreatePhones(PhoneDTO id)
        {
            throw new NotImplementedException();
        }

        public Task<Phone> DeletePhone(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Phone> GetPhone(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Phone>> GetPhones()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePhone(UpdatePhoneDTO phone)
        {
            throw new NotImplementedException();
        }
    }
}
