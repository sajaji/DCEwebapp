using Microsoft.AspNetCore.Mvc;
using DCEwebapp.Models;
using DCEwebapp.Data; 

namespace DCEwebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCntrlr : ControllerBase
    {
        private readonly DCEDbContext _context; 

        public CustomerCntrlr(DCEDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCntrlr
        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                
                var customers = new List<Customer>
        {
            new Customer { UserId = Guid.NewGuid(), Username = "Sajaji", Email = "sajaji@icloud.com" },
            new Customer { UserId = Guid.NewGuid(), Username = "Hasmi", Email = "hasmi@gmail.com" }
        };

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
            }

        // GET: api/CustomerCntrlr/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            return Ok();
        }

        // POST: api/CustomerCntrlr/CreateCustomer
        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.UserId }, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        // PUT: api/CustomerCntrlr/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Guid id, [FromBody] Customer customer)
        {
            return NoContent();
        }

        // DELETE: api/CustomerCntrlr/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            return NoContent();
        }
    }
}
