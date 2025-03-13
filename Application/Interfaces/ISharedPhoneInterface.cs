using Application.DTO_s.Phone;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISharedPhoneInterface
    {
        Task<ICollection<SharedPhone>> GetPhone2Persons();
        Task<int> Create2phones(SharedPhoneDTO id);
        Task<SharedPhone> GetPhone2Person(int id);
        Task<SharedPhone> Delete2Persons(int id);
        Task<int> UpdatePhone2Person(UpdateSharedPhoneDTO updateperson2PhonesDTO);
    }
}
