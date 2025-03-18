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
        var person = await _personInterface.CreatePerson(personDTO);
        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> UploadPersonImage(int personId, IFormFile imageFile)
    {
        var person = await _personInterface.UploadPersonImage(personId, imageFile);
        return Ok(person);
    }

    [HttpGet]
    public async Task<IActionResult> GetPersonsQuickSearch(string? firstName, string? lastName, string? personalNumber)
    {
        var persons = await _personInterface.GetPersonsQuickSearch(firstName, lastName, personalNumber);
        return Ok(persons);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetPersonByDetailedSearch([FromQuery] GetPersonDTO getPersonDTO)
    //{
    //    var person = await _personInterface.GetPersonByDetailedSearch(getPersonDTO);
    //    return Ok(person);
    //}

    [HttpGet]
    public async Task<IActionResult> GetPersonsByPaging(int pageNumber, int pageSize)
    {
        var persons = await _personInterface.GetPersonsByPaging(pageNumber, pageSize);
        return Ok(persons);
    }

    [HttpGet]
    public async Task<IActionResult> GetConnectedPersonsCount(int personId, ConnectionType connectionType)
    {
        var connectedPersonsCount = await _personInterface.GetConnectedPersonsCount(personId, connectionType);
        return Ok(connectedPersonsCount);
    }

    [HttpGet]
    public async Task<IActionResult> GetPerson(int id)
    {
        var person = await _personInterface.GetPerson(id);
        return Ok(person);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDTO updatePersonDTO)
    {
        var updatedPerson = await _personInterface.UpdatePerson(updatePersonDTO);
        return Ok(updatedPerson);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var person = await _personInterface.DeletePerson(id);
        return Ok(person);
    }
    #endregion

    #region ConnectedPerson
    [HttpPost]
    public async Task<IActionResult> CreateConnections([FromBody] ConnectedPersonDTO connectedPersonDTO)
    {
        var connectedPerson = await _connectedPersonInterface.CreateConnections(connectedPersonDTO);
        return Ok(connectedPerson);
    }

    [HttpGet]
    public async Task<IActionResult> GetConnections()
    {
        var connectedPersons = await _connectedPersonInterface.GetConnections();
        return Ok(connectedPersons);
    }

    [HttpGet]
    public async Task<IActionResult> GetConnection(int id)
    {
        var connectedPerson = await _connectedPersonInterface.GetConnection(id);
        return Ok(connectedPerson);
    }

    //[HttpPut]
    //public async Task<IActionResult> UpdateConnectedPerson([FromBody] UpdateConnectedPersonDTO updateConnectedPersonDTO)
    //{
    //    var updatedConnectedPerson = await _connectedPersonInterface.UpdateConnectedPerson(updateConnectedPersonDTO);
    //    return Ok(updatedConnectedPerson);
    //}

    [HttpDelete]
    public async Task<IActionResult> DeleteConnections(int id)
    {
        var connectedPerson = await _connectedPersonInterface.DeleteConnection(id);
        return Ok(connectedPerson);
    }
    #endregion
}
