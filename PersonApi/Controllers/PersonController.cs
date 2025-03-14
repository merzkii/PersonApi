using Application.DTO_s;
using Application.DTO_s.Person;
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

    #region Person
    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] PersonDTO personDTO)
    {
        if (personDTO == null)
        {
            return BadRequest();
        }
        var person = await _personInterface.CreatePerson(personDTO);
        return Ok(person);
    }

    [HttpGet]
    public async Task<IActionResult> GetPersons()
    {
        var persons = await _personInterface.GetPersons();
        return Ok(persons);
    }

    [HttpGet]
    public async Task<IActionResult> GetPerson(int id)
    {
        var person = await _personInterface.GetPerson(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDTO updatePersonDTO)
    {
        if (updatePersonDTO == null)
        {
            return BadRequest();
        }
        var updatedPerson = await _personInterface.UpdatePerson(updatePersonDTO);
        return Ok(updatedPerson);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var person = await _personInterface.DeletePerson(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
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
        var connectedPerson = await _connectedPersonInterface.CreateConnectedPersons(connectedPersonDTO);
        return Ok(connectedPerson);
    }

    [HttpGet]
    public async Task<IActionResult> GetConnectedPersons()
    {
        var connectedPersons = await _connectedPersonInterface.GetConnectedPersons();
        return Ok(connectedPersons);
    }

    [HttpGet]
    public async Task<IActionResult> GetConnectedPerson(int id)
    {
        var connectedPerson = await _connectedPersonInterface.GetConnectedPerson(id);
        if (connectedPerson == null)
        {
            return NotFound();
        }
        return Ok(connectedPerson);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateConnectedPerson([FromBody] UpdateConnectedPersonDTO updateConnectedPersonDTO)
    {
        if (updateConnectedPersonDTO == null)
        {
            return BadRequest();
        }
        var updatedConnectedPerson = await _connectedPersonInterface.UpdateConnectedPerson(updateConnectedPersonDTO);
        return Ok(updatedConnectedPerson);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteConnectedPerson(int id)
    {
        var connectedPerson = await _connectedPersonInterface.DeleteConnectedPerson(id);
        if (connectedPerson == null)
        {
            return NotFound();
        }
        return Ok(connectedPerson);
    }


    #endregion

}
