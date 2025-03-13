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
        public PhoneController(IPhoneInterface phoneInterface, ISharedPhoneInterface sharedPhoneInterface)
        {
            _phoneInterface = phoneInterface;
            _sharedPhoneInterface = sharedPhoneInterface;
        }
    }
}
