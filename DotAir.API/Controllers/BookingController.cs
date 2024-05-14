using DotAir.API.DTO.Booking;
using DotAir.BLL.Services;
using DotAir.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotAir.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(BookingService _bookingService) : ControllerBase
    {

        [HttpPost]
        [Authorize(Roles = "CUSTOMER")]
        public IActionResult Register([FromBody] RegisterBookingDTO dto)
        {
            try
            {
                Booking b = _bookingService.Register(dto.CustomerId, dto.FlightId);
                return Created("", new BookingDTO(b));
            }
            catch (ValidationException ex) 
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
