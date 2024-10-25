using Biblioteca.Application.DTOs;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BookReservationController : ControllerBase
{
    private readonly IBookReservationService _service;

    public BookReservationController(IBookReservationService service)
    {
        _service = service;
    }

    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<ReservationDto>>> GetAllReservations()
    {
        var reservations = await _service.GetAllReservations();
        return Ok(reservations);
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<ReservationDto>>> GetReservationsByUserId(int id)
    {
        var reservations = await _service.GetReservationsByUserId(id);
        return Ok(reservations);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<ReservationDto>>> GetReservationsByUserToken()
    {
        try
        {
            var token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            var reservations = await _service.GetReservationsByUserToken(token);
            return Ok(reservations);
        }
        catch (DataNotFoundException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPost("{idBook:int}")]
    [Authorize]
    public async Task<ActionResult<ReservationDto>> CreateNewReservation(int idBook)
    {
        try
        {
            var token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            var reservation = await _service.CreateNewReservation(idBook, token);
            return Ok(reservation);
        }
        catch (DataNotFoundException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPatch("closeReservation/{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ReservationDto>> CloseReservation(int id)
    {
        try
        {
            var closedReservation = await _service.CloseReservation(id);
            return Ok(closedReservation);
        }
        catch (DataNotFoundException e)
        {
            return BadRequest(new { message = e.Message });
        }
        
        
    }
    
}