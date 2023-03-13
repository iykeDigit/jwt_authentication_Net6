using DemoAuth.Core;
using DemoAuth.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAuth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authentication;

        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserRequest userRequest) 
        {
            try
            {
                return Ok(await _authentication.Login(userRequest));
            }
            catch (AccessViolationException)
            {
                return BadRequest();
            }
            catch(Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequest registrationRequest) 
        {
            try
            {
                var result = await _authentication.Register(registrationRequest);
                //return CreatedAtAction(nameof(GetProduct), new { Id = result.Id }, result);
                return Created("", result);
            }
            catch (MissingFieldException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
