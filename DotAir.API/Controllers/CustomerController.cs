using DotAir.API.DTO.Airport;
using DotAir.API.DTO.Customer;
using DotAir.BLL.Services;
using DotAir.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotAir.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(CustomerService _customerService) : ControllerBase
    {

        [HttpPost]
        public IActionResult Register([FromBody] RegisterDTO dto)
        {
            Customer customer = _customerService
                .Register(
                    dto.LastName, 
                    dto.FirstName, 
                    dto.Password, 
                    dto.BirthDate
            );

            // retourner un résultat
            return Created("", new CustomerDTO(customer));
        }


        [HttpGet]
        public IActionResult Search([FromQuery] SearchCustomerDTO dto)
        {
            List<Customer> results = _customerService.Search(dto.LastName, dto.FirstName, dto.Email, dto.Domain);
            return Ok(results.Select(c => new CustomerDTO(c)));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                _customerService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]UpdateCustomerDTO dto)
        {
            try
            {
                _customerService.Update(id, dto.LastName, dto.FirstName, dto.Password);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
