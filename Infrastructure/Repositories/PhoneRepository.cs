using Application.DTO_s.Phone;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Core.Enums;
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
            var phonetype = number.Type;    
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

        public async Task<int> DeletePhone(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
                throw new NullReferenceException("Record Not Found");
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
            return phone.Id;
        }

        public async Task<PhoneDTO> GetPhone(int id)
        {
            var phone = await _context.Phones.SingleOrDefaultAsync(p => p.Id == id);
                                             
            if (phone == null)
                throw new NullReferenceException("Record Not Found");


            return phone.CreateDTO();
        }

        public async Task<List<GetPhonesDTO>> GetPhones()
        {
            var phones = await _context.Phones.OrderBy(p => p.Id).ToListAsync();
            if (phones == null)
                throw new NullReferenceException("Record Not Found");
            return phones.Select(p=>p.CreateDTO()).ToList();
        }

        public async Task<int> UpdatePhone(UpdatePhoneDTO phone)
        {
            var existingPhone = await _context.Phones.FindAsync(phone.Id);
            if (existingPhone == null)
                throw new NullReferenceException("Record Not Found");
            var phoneWithSameNumber = await _context.Phones.SingleOrDefaultAsync(p => p.Number == phone.Number && p.Type == phone.Type);
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
