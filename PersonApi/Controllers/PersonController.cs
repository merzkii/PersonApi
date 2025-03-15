using Application.DTO_s;
using Application.DTO_s.Person;
using Application.Interfaces;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PersonController : ControllerBase
{
    private readonly IPersonInterface _personInterface;
    private readonly IConnectedPersonInterface _connectedPersonInterface;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonInterface personInterface, IConnectedPersonInterface connectedPersonInterface, ILogger<PersonController> logger)
    {
        _personInterface = personInterface;
        _connectedPersonInterface = connectedPersonInterface;
        _logger = logger;
    }

    #region Person
    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] PersonDTO personDTO)
    {
        if (personDTO == null)
        {
            return BadRequest();
        }

        try
        {
            var person = await _personInterface.CreatePerson(personDTO);
            return Ok(person);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreatePerson: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPersonsQuickSearch(string searchTerm, int pageNumber, int pageSize)
    {
        try
        {
            var persons = await _personInterface.GetPersonsQuickSearch(searchTerm,pageNumber,pageSize);
            return Ok(persons);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetPersons: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPersonsDetailedSearch (int pageNumber, int pageSize)
    {
        try
        {
            var persons = await _personInterface.GetPersonsDetailedSearch(pageNumber,pageSize);
            return Ok(persons);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetPersons: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetConnectedPersonsCount(int personId, ConnectionType connectionType)
    {
        try
        {
            var connectedPersonsCount = await _personInterface.GetConnectedPersonsCount(personId, connectionType);
            return Ok(connectedPersonsCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetConnectedPersonsCount: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPerson(int id)
    {
        try
        {
            var person = await _personInterface.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetPerson: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDTO updatePersonDTO)
    {
        if (updatePersonDTO == null)
        {
            return BadRequest();
        }

        try
        {
            var updatedPerson = await _personInterface.UpdatePerson(updatePersonDTO);
            return Ok(updatedPerson);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdatePerson: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePerson(int id)
    {
        try
        {
            var person = await _personInterface.DeletePerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeletePerson: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }
    #endregion

    #region ConnectedPerson
    [HttpPost]
    public async Task<IActionResult> CreateConnectedPerson([FromBody] ConnectedPersonDTO connectedPersonDTO)
    {
        if (connectedPersonDTO == null)
        {
            return BadRequest();
        }

        try
        {
            var connectedPerson = await _connectedPersonInterface.CreateConnectedPersons(connectedPersonDTO);
            return Ok(connectedPerson);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateConnectedPerson: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetConnectedPersons()
    {
        try
        {
            var connectedPersons = await _connectedPersonInterface.GetConnectedPersons();
            return Ok(connectedPersons);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetConnectedPersons: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetConnectedPerson(int id)
    {
        try
        {
            var connectedPerson = await _connectedPersonInterface.GetConnectedPerson(id);
            if (connectedPerson == null)
            {
                return NotFound();
            }
            return Ok(connectedPerson);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetConnectedPerson: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateConnectedPerson([FromBody] UpdateConnectedPersonDTO updateConnectedPersonDTO)
    {
        if (updateConnectedPersonDTO == null)
        {
            return BadRequest();
        }

        try
        {
            var updatedConnectedPerson = await _connectedPersonInterface.UpdateConnectedPerson(updateConnectedPersonDTO);
            return Ok(updatedConnectedPerson);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateConnectedPerson: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteConnectedPerson(int id)
    {
        try
        {
            var connectedPerson = await _connectedPersonInterface.DeleteConnectedPerson(id);
            if (connectedPerson == null)
            {
                return NotFound();
            }
            return Ok(connectedPerson);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteConnectedPerson: Internal server error");
            return StatusCode(500, "Internal server error");
        }
    }
    #endregion
}
