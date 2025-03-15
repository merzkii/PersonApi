using Application.DTO_s.City;
using Core.Models;

namespace Application.Interfaces
{
    public interface ICityInterface
    {
        Task<ICollection<ExistingCityDTO>> GetCities();
        Task<ExistingCityDTO> GetCity(int id);
        Task<int> CreateCity(CityDTO name);
        Task<int> DeleteCity(int id);
        Task<int> UpdateCity(ExistingCityDTO city);
    }
}
