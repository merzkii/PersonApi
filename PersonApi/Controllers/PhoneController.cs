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
            if (phone == null)
            {
                return BadRequest("Phone data is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newPhone = await _phoneInterface.CreatePhone(phone);
            if (newPhone == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating phone");
            }
            return Ok("Phone Has Been Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetPhones()
        {
            var phones = await _phoneInterface.GetPhones();
            if (phones == null || !phones.Any())
            {
                return NotFound("No phones found");
            }
            return Ok(phones);
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneById(int id)
        {
            var phone = await _phoneInterface.GetPhone(id);
            if (phone == null)
            {
                return NotFound("Phone not found");
            }
            return Ok(phone);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePhone(UpdatePhoneDTO phone)
        {
            if (phone == null)
            {
                return BadRequest("Phone data is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateResult = await _phoneInterface.UpdatePhone(phone);
            if (updateResult == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating phone");
            }
            return Ok("Phone Has Been Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhone(int id)
        {
            var phone = await _phoneInterface.DeletePhone(id);
            if (phone == null)
            {
                return NotFound("Phone not found");
            }
            return Ok("Phone Has Been Deleted");
        }
        #endregion

        #region SharedPhone

        [HttpPost]
        public async Task<IActionResult> AddSharedPhone([FromBody] SharedPhoneDTO sharedPhone)
        {
            if (sharedPhone == null)
            {
                return BadRequest("SharedPhone data is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSharedPhone = await _sharedPhoneInterface.CreateSharedphone(sharedPhone);
            if (newSharedPhone == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating shared phone");
            }
            return Ok("SharedPhone Has Been Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetSharedPhones()
        {
            var sharedPhones = await _sharedPhoneInterface.GetSharedPhones();
            if (sharedPhones == null || !sharedPhones.Any())
            {
                return NotFound("No shared phones found");
            }
            return Ok(sharedPhones);
        }

        [HttpGet]
        public async Task<IActionResult> GetSharedPhoneById(int id)
        {
            var sharedPhone = await _sharedPhoneInterface.GetSharedPhone(id);
            if (sharedPhone == null)
            {
                return NotFound("SharedPhone not found");
            }
            return Ok(sharedPhone);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSharedPhone(UpdateSharedPhoneDTO sharedPhone)
        {
            if (sharedPhone == null)
            {
                return BadRequest("SharedPhone data is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateResult = await _sharedPhoneInterface.UpdateSharedPhone(sharedPhone);
            if (updateResult == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating shared phone");
            }
            return Ok("SharedPhone Has Been Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSharedPhone(int id)
        {
            var sharedPhone = await _sharedPhoneInterface.DeleteSharedPhone(id);
            if (sharedPhone == null)
            {
                return NotFound("SharedPhone not found");
            }
            return Ok("SharedPhone Has Been Deleted");
        }

        #endregion
    }
}
