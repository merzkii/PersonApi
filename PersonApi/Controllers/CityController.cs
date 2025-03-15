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
        private readonly ILogger<CityController> _logger;

        public CityController(ICityInterface cityInterface, ILogger<CityController> logger)
        {
            _cityInterface = cityInterface;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var cities = await _cityInterface.GetCities();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting cities.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCityById(int id)
        {
            try
            {
                var city = await _cityInterface.GetCity(id);
                if (city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting city with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityDTO city)
        {
            try
            {
                var newCity = await _cityInterface.CreateCity(city);
                return Ok("City Has Been Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new city.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                var city = await _cityInterface.DeleteCity(id);
                return Ok("City Has Been Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting city with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(ExistingCityDTO city)
        {
            try
            {
                var updateResult = await _cityInterface.UpdateCity(city);
                if (updateResult == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating city");
                }

                var updatedCity = await _cityInterface.GetCity(city.Id);
                return Ok(updatedCity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating city with id {city.Id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
