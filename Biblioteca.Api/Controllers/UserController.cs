using Biblioteca.Application.DTOs.User;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("/api/[controller]s")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<UserOutputDto>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserOutputDto>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return BadRequest(new { message = $"User not found. ID={id}" });
        }

        return Ok(user);
    }
    
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserOutputDto>> UpdateUser(int id, [FromBody] UserDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = ModelState });
        }

        try
        {
            var user = await _userService.UpdateUserAsync(id, model);
            return Ok(user);
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new { message = e.Message});
        }
    }
}