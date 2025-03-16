using Application.DTO_s.Phone;
using Application.Interfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Layer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PhoneRepository : IPhoneInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PhoneRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreatePhone(PhoneDTO number)
        {
            var existingPhone = await _context.Phones.SingleOrDefaultAsync(p => p.Number == number.Number);
            if (existingPhone != null)
            {
                throw new InvalidOperationException($"Phone with number {number.Number} already exists.");
            }
            var phone = _mapper.Map<Phone>(number);
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();
            return phone.Id;
        }

        public async Task<Phone> DeletePhone(int id)
        {
            var phone = await GetPhone(id);
            if (phone == null)
                throw new NullReferenceException("Record Not Found");
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
            return phone;
        }

        public async Task<Phone> GetPhone(int id)
        {
            var phone = await _context.Phones.SingleOrDefaultAsync(p => p.Id == id);
            if (phone == null)
                throw new NullReferenceException("Record Not Found");
            return phone;
        }

        public async Task<ICollection<Phone>> GetPhones()
        {
            var phones = await _context.Phones.OrderBy(p => p.Id).ToListAsync();
            return phones;
        }

        public async Task<int> UpdatePhone(UpdatePhoneDTO phone)
        {
            var existingPhone = await GetPhone(phone.Id);
            if (existingPhone == null)
                throw new NullReferenceException("Record Not Found");
            var phoneWithSameNumber = await _context.Phones.SingleOrDefaultAsync(p => p.Number == phone.Number);
            if (phoneWithSameNumber != null && phoneWithSameNumber.Id != phone.Id)
            {
                throw new InvalidOperationException($"Phone with number {phone.Number} already exists.");
            }
            var newPhone = _mapper.Map<Phone>(phone);
            _context.Entry(existingPhone).CurrentValues.SetValues(newPhone);
            await _context.SaveChangesAsync();
            return existingPhone.Id;
        }
    }
}
