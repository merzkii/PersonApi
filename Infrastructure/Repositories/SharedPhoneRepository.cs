using Application.DTO_s.Phone;
using Application.Interfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Layer;
using Microsoft.EntityFrameworkCore;

namespace PersonApi
{
    public class SharedPhoneRepository : ISharedPhoneInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SharedPhoneRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateSharedphone(SharedPhoneDTO id)
        {
            if (await _context.SharedPhones.AnyAsync(s => s.PhoneId == id.PhoneId && s.PersonId == id.PersonId))
                throw new InvalidOperationException($"Shared Phone with PhoneId {id.PhoneId} and PersonId {id.PersonId} already exists.");
            var sharedPhone=_mapper.Map<SharedPhone>(id);
            _context.SharedPhones.Add(sharedPhone);
            await _context.SaveChangesAsync();
            return sharedPhone.Id;
        }

        public async Task<SharedPhone> DeleteSharedPhone(int id)
        {
            var sharedPhone = await GetSharedPhone(id);
            if (sharedPhone == null)
                throw new NullReferenceException("Record Not Found");
            _context.SharedPhones.Remove(sharedPhone);
            await _context.SaveChangesAsync();
            return sharedPhone;
        }

        public async Task<SharedPhone> GetSharedPhone(int id)
        {
            var sharedPhone = await _context.SharedPhones
                .Include(s => s.Phone)
                .Include(s => s.Person)
                .SingleOrDefaultAsync(s => s.Id == id);
            if (sharedPhone == null)
                throw new NullReferenceException("Record Not Found");
            return sharedPhone;
        }

        public async Task<ICollection<SharedPhone>> GetSharedPhones()
        {
            if (!await _context.SharedPhones.AnyAsync())
                throw new NullReferenceException("Record Not Found");
            return await _context.SharedPhones.OrderBy(s=>s.Id).ToListAsync();
        }

        public async Task<int> UpdateSharedPhone(UpdateSharedPhoneDTO updateSharedPhonesDTO)
        {
            var existingSharedPhone=await GetSharedPhone(updateSharedPhonesDTO.Id);
            if (existingSharedPhone == null)
                throw new NullReferenceException("Record Not Found");
            if (await _context.SharedPhones.AnyAsync(s => s.PhoneId == updateSharedPhonesDTO.PhoneId && s.PersonId == updateSharedPhonesDTO.PersonId))
                throw new InvalidOperationException($"Shared Phone with PhoneId {updateSharedPhonesDTO.PhoneId} and PersonId {updateSharedPhonesDTO.PersonId} already exists.");
            var sharedPhone = _mapper.Map<SharedPhone>(updateSharedPhonesDTO);
            _context.Entry(existingSharedPhone).CurrentValues.SetValues(sharedPhone);
            await _context.SaveChangesAsync();
            return existingSharedPhone.Id;
        }
    }
}
