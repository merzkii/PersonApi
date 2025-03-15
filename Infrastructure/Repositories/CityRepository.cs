using Application.DTO_s.City;
using Application.Interfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Layer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CityRepository : ICityInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CityRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateCity(CityDTO cityDTO)
        {
            var existingCity = await _context.Cities.SingleOrDefaultAsync(c => c.Name == cityDTO.Name);
            if (existingCity != null)
            {
                throw new InvalidOperationException($"City with name {cityDTO.Name} already exists.");
            }

            var city = _mapper.Map<City>(cityDTO);
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city.Id;
        }

        public async Task<int> DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
                throw new NullReferenceException($"Record Not Found On {id}-id");
            _context.Cities.Remove(city);
            return await _context.SaveChangesAsync();


        }

        public async Task<ICollection<ExistingCityDTO>> GetCities()
        {
            var cities = await _context.Cities.OrderBy(c => c.Id).ToListAsync();
            return cities.Select(c => new ExistingCityDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }

        public async Task<ExistingCityDTO> GetCity(int id)
        {
            var city = await _context.Cities.SingleOrDefaultAsync(x => x.Id == id);
            if (city == null)
                throw new NullReferenceException("Record Not Found");
            return new ExistingCityDTO
            {
                Id = city.Id,
                Name = city.Name
            };
        }

        public async Task<int> UpdateCity(ExistingCityDTO updateCityDTO)
        {
            var existingCity = await _context.Cities.FindAsync(updateCityDTO.Id);
            if (existingCity == null)
                throw new NullReferenceException("Record Not Found");

            var cityWithSameName = await _context.Cities.SingleOrDefaultAsync(c => c.Name == updateCityDTO.Name && c.Id != updateCityDTO.Id);
            if (cityWithSameName != null)
                throw new InvalidOperationException($"City with name {updateCityDTO.Name} already exists.");

            var city = _mapper.Map<City>(updateCityDTO);
            _context.Entry(existingCity).CurrentValues.SetValues(city);
            await _context.SaveChangesAsync();
            return city.Id;
        }
    }
}
