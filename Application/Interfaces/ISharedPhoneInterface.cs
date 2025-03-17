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
        Task<int> CreateSharedphone(SharedPhoneDTO id);
        Task<List<GetSharedPhonesDTO>> GetSharedPhones();
        Task<GetSharedPhonesDTO> GetSharedPhone(int id);
        Task<int> DeleteSharedPhone(int id);
        Task<int> UpdateSharedPhone(UpdateSharedPhoneDTO updateperson2PhonesDTO);
    }
}
