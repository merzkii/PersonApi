using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PersonController : ControllerBase
{
   private readonly IPersonInterface _personInterface;
   private readonly IConnectedPersonInterface _connectedPersonInterface;
    public PersonController(IPersonInterface personInterface, IConnectedPersonInterface connectedPersonInterface)
    {
        _personInterface = personInterface;
        _connectedPersonInterface = connectedPersonInterface;
    }
}
