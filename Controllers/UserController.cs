using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Communication.Request;
using MyFirstAPI.Communication.Response;

namespace MyFirstAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseCreateUserJson),StatusCodes.Status200OK)]
    [Route("/search/{id}")]
    public IActionResult Get([FromRoute] string id) 
    {
        var userAlwaredyExists = new ResponseCreateUserJson
        {
            Id = "1",
            Name = "John Doe"
        };
        return Ok(userAlwaredyExists);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseCreateUserJson),StatusCodes.Status200OK)]
    [Route("/search/query")]
    public IActionResult GetName([FromQuery] string name)
    {
        var userAlwaredyExists = new ResponseCreateUserJson
        {
            Id = "1",
            Name = name
        };
        return Ok(userAlwaredyExists);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateUserJson),StatusCodes.Status201Created)]
    [Route("/create")]
    public IActionResult Create([FromBody] RequestCreateUserJson request)
    {
        var userCreated = new ResponseCreateUserJson
        {
            Id = "1",
            Name = request.Name
        };
        return CreatedAtAction(nameof(Get), new { id = userCreated.Id }, userCreated);
    }

}
