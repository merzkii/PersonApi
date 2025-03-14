using Application.DTO_s.Phone;
using Core.Models;

namespace Application.Interfaces
{
    public interface IPhoneInterface
    {
        Task<int> CreatePhone(PhoneDTO number);
        Task<ICollection<Phone>> GetPhones();
        Task<Phone> GetPhone(int id);
        Task<Phone> DeletePhone(int id);
        Task<int> UpdatePhone(UpdatePhoneDTO phone);
    }
}
