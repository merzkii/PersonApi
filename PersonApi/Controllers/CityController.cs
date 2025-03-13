using Application.Interfaces;
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
    }
}
