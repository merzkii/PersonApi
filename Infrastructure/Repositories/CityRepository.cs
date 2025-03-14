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

        public async Task<int> CreateCity(CityDTO name)
        {
           var city = _mapper.Map<City>(name);
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city.Id;
        }

        public async Task<City> DeleteCity(int id)
        {
            var city =await GetCity(id);
            if (city == null)
                throw new NullReferenceException("Record Not Found");
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return city;

        }

        public async Task<ICollection<City>> GetCities()
        {
           var cities = await _context.Cities.OrderBy(c=>c.Id).ToListAsync();
            return cities;  
        }

        public async Task<City> GetCity(int id)
        {
            var city = await _context.Cities.SingleOrDefaultAsync(x => x.Id == id);
            if (city == null)
                throw new NullReferenceException("Record Not Found");
            return city;
        }

        public async Task<int> UpdateCity(UpdateCityDTO updateCityDTO)
        {
            var existingCity = await GetCity(updateCityDTO.Id);
            if(existingCity == null)
                throw new NullReferenceException("Record Not Found");
            var city = _mapper.Map<City>(updateCityDTO);
            _context.Entry(existingCity).CurrentValues.SetValues(city);
            await _context.SaveChangesAsync();
            return city.Id;
        }
    }
}
