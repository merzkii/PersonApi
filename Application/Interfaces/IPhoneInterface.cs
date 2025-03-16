using Application.DTO_s.Phone;
using Core.Models;

namespace Application.Interfaces
{
    public interface IPhoneInterface
    {
        Task<int> CreatePhone(PhoneDTO number);
        Task<List<GetPhonesDTO>> GetPhones();
        Task<PhoneDTO> GetPhone(int id);
        Task<int> DeletePhone(int id);
        Task<int> UpdatePhone(UpdatePhoneDTO phone);
    }
}
