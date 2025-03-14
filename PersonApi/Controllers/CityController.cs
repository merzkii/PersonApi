using Application.DTO_s.City;
using Application.Interfaces;
using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityInterface _cityInterface;
        public CityController(ICityInterface cityInterface)
        {
            _cityInterface = cityInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityInterface.GetCities();
            return Ok(cities);
        }

        [HttpGet]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _cityInterface.GetCity(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityDTO city)
        {
            var newCity = await _cityInterface.CreateCity(city);
            return Ok("City Has Been Created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = _cityInterface.DeleteCity(id);
            return Ok("City Has Been Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(UpdateCityDTO city)
        {
            var updateResult = await _cityInterface.UpdateCity(city);
            if (updateResult == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating city");
            }


            var updatedCity = await _cityInterface.GetCity(city.Id);
            return Ok(updatedCity);
        }
    }
}
