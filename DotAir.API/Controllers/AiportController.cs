using DotAir.API.DTO.Airport;
using DotAir.BLL.Services;
using DotAir.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotAir.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiportController(AirportService _airportService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Add([FromBody] AirportFormDTO dto)
        {
            Airport airport = _airportService.Add(dto.City, dto.Country, dto.Code);
            return Created("", new AirportDTO(airport));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                _airportService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] AirportFormDTO dto)
        {
            try
            {
                _airportService.Update(id, dto.City, dto.Country, dto.Code);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Search([FromQuery] string? isocode, [FromQuery] string? keyword)
        {
            return Ok(
                _airportService.Search(keyword, isocode)
                    .Select(a => new AirportDTO(a))
            );
        }
    }
}
