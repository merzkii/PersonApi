using Application.DTO_s.City;
using Core.Models;

namespace Application.Interfaces
{
    public interface ICityInterface
    {
        Task<ICollection<City>> GetCities();
        Task<City> GetCity(int id);
        Task<int> CreateCity(CityDTO name);
        Task<City> DeleteCity(int id);
        Task<int> UpdateCity(UpdateCityDTO city);
    }
}
