using Biblioteca.Application.DTOs.User;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Domain.Enuns;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signup")]
    public async Task<ActionResult<TokenDto>> SignUp([FromBody] UserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = ModelState });
        }
        
        var tokenDto = await _authService.SignUp(dto, UserRole.Reader);
        
        return CreatedAtAction("GetUserById", "User", new { id = tokenDto.Id }, tokenDto);
    }
    
    [HttpPost("signup/admin")]
    public async Task<ActionResult<TokenDto>> SignUpAdmin([FromBody] UserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = ModelState });
        }
        
        var tokenDto = await _authService.SignUp(dto, UserRole.Admin);
        
        return CreatedAtAction("GetUserById", "User", new { id = tokenDto.Id }, tokenDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = ModelState });
        }

        try
        {
            var tokenDto = await _authService.Login(dto);
            return Ok(tokenDto);
        }
        catch (CredentialsNotValidException e)
        {
            return BadRequest(new { message = e.Message });
        }
        
    }
    
}