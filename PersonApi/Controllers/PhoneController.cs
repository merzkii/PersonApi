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

            try
            {
                var newPhone = await _phoneInterface.CreatePhone(phone);
                if (newPhone == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating phone");
                }
                return Ok("Phone Has Been Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating phone");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPhones()
        {
            try
            {
                var phones = await _phoneInterface.GetPhones();
                if (phones == null || !phones.Any())
                {
                    return NotFound("No phones found");
                }
                return Ok(phones);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving phones");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneById(int id)
        {
            try
            {
                var phone = await _phoneInterface.GetPhone(id);
                if (phone == null)
                {
                    return NotFound("Phone not found");
                }
                return Ok(phone);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving phone with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
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
            try
            {
                var updateResult = await _phoneInterface.UpdatePhone(phone);
                if (updateResult == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating phone");
                }
                return Ok("Phone Has Been Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating phone with id {phone.Id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhone(int id)
        {
            try
            {
                var phone = await _phoneInterface.DeletePhone(id);
                if (phone == null)
                {
                    return NotFound("Phone not found");
                }
                return Ok("Phone Has Been Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting phone with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
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
            try
            {
                var newSharedPhone = await _sharedPhoneInterface.CreateSharedphone(sharedPhone);
                if (newSharedPhone == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating shared phone");
                }
                return Ok("SharedPhone Has Been Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating shared phone");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSharedPhones()
        {
            try
            {
                var sharedPhones = await _sharedPhoneInterface.GetSharedPhones();
                if (sharedPhones == null || !sharedPhones.Any())
                {
                    return NotFound("No shared phones found");
                }
                return Ok(sharedPhones);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving shared phones");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSharedPhoneById(int id)
        {
            try
            {
                var sharedPhone = await _sharedPhoneInterface.GetSharedPhone(id);
                if (sharedPhone == null)
                {
                    return NotFound("SharedPhone not found");
                }
                return Ok(sharedPhone);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving shared phone with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
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
            try
            {
                var updateResult = await _sharedPhoneInterface.UpdateSharedPhone(sharedPhone);
                if (updateResult == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating shared phone");
                }
                return Ok("SharedPhone Has Been Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating shared phone with id {sharedPhone.Id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSharedPhone(int id)
        {
            try
            {
                var sharedPhone = await _sharedPhoneInterface.DeleteSharedPhone(id);
                if (sharedPhone == null)
                {
                    return NotFound("SharedPhone not found");
                }
                return Ok("SharedPhone Has Been Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting shared phone with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        #endregion
    }
}
