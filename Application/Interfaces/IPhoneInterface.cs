using Application.DTO_s.Phone;
using Core.Models;

namespace Application.Interfaces
{
    public interface IPhoneInterface
    {
        Task<ICollection<Phone>> GetPhones();
        Task<int> CreatePhones(PhoneDTO id);
        Task<Phone> GetPhone(int id);
        Task<Phone> DeletePhone(int id);
        Task<int> UpdatePhone(UpdatePhoneDTO phone);    
    }
}
