using Application.DTO_s.City;
using Application.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CityRepository : ICityInterface
    {
        public Task<int> CreateCity(CityDTO name)
        {
            throw new NotImplementedException();
        }

        public Task<City> DeleteCity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<City>> GetCities()
        {
            throw new NotImplementedException();
        }

        public Task<City> GetCity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCity(UpdateCityDTO city)
        {
            throw new NotImplementedException();
        }
    }
}
