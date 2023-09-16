using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DCEwebapp.DataAccess; 
using DCEwebapp.Models; 

namespace DCEwebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCntrlr : ControllerBase
    {
        private readonly OrderDAL _orderDAL; 

        public OrderCntrlr(OrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }


        // GET: api/OrderCntrlr/ActiveOrdersByCustomer/{customerId}
        [HttpGet("ActiveOrdersByCustomer/{customerId}")]
        public IActionResult GetActiveOrdersByCustomer(Guid customerId)
        {
            try
            {
                var activeOrders = new List<Orders>
                {
                    new Orders { OrderId = Guid.NewGuid(), OrderStatus = 1 },
                    new Orders { OrderId = Guid.NewGuid(), OrderStatus = 1 },
                    
                };

                return Ok(activeOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
