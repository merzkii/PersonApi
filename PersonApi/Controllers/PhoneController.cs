using Application.DTO_s.Phone;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneInterface _phoneInterface;
        private readonly ISharedPhoneInterface _sharedPhoneInterface;
        private readonly ILogger<PhoneController> _logger;

        public PhoneController(IPhoneInterface phoneInterface, ISharedPhoneInterface sharedPhoneInterface, ILogger<PhoneController> logger)
        {
            _phoneInterface = phoneInterface;
            _sharedPhoneInterface = sharedPhoneInterface;
            _logger = logger;
        }

        #region Phone

        [HttpPost]
        public async Task<IActionResult> AddPhone([FromBody] PhoneDTO phone)
        {
            var newPhone = await _phoneInterface.CreatePhone(phone);
            return Ok(newPhone);
        }

        [HttpGet]
        public async Task<IActionResult> GetPhones()
        {
            var phones = await _phoneInterface.GetPhones();
            return Ok(phones);
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneById(int id)
        {
            var phone = await _phoneInterface.GetPhone(id);
            return Ok(phone);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePhone(UpdatePhoneDTO phone)
        {
            var updateResult = await _phoneInterface.UpdatePhone(phone);
            return Ok(updateResult);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhone(int id)
        {
            var phone = await _phoneInterface.DeletePhone(id);
            return Ok(phone);
        }
        #endregion

        #region SharedPhone

        [HttpPost]
        public async Task<IActionResult> AddSharedPhone([FromBody] SharedPhoneDTO sharedPhone)
        {
            var newSharedPhone = await _sharedPhoneInterface.CreateSharedphone(sharedPhone);
            return Ok(newSharedPhone);
        }

        [HttpGet]
        public async Task<IActionResult> GetSharedPhones()
        {
            var sharedPhones = await _sharedPhoneInterface.GetSharedPhones();
            return Ok(sharedPhones);
        }

        [HttpGet]
        public async Task<IActionResult> GetSharedPhoneById(int id)
        {
            var sharedPhone = await _sharedPhoneInterface.GetSharedPhone(id);
            return Ok(sharedPhone);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSharedPhone(UpdateSharedPhoneDTO sharedPhone)
        {
            var updateResult = await _sharedPhoneInterface.UpdateSharedPhone(sharedPhone);
            return Ok(updateResult);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSharedPhone(int id)
        {
            var sharedPhone = await _sharedPhoneInterface.DeleteSharedPhone(id);
            return Ok(sharedPhone);
        }

        #endregion
    }
}
