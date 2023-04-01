using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WAD_CW_11064.Models;
using WAD_CW_11064.Repositories;

namespace WAD_CW_11064.Controllers

    {
        [Route("api/Order")]
        [ApiController]
        public class OrderController : ControllerBase
        {
            private readonly IOrderRepository _orderRepository;
            public OrderController(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            // GET: api/Order
            [HttpGet]
            public IActionResult Get()
            {
                var order = _orderRepository.GetOrder();
                return new OkObjectResult(order);
            }
        // GET: api/Order/5 
            public IActionResult Get(int id)
            {
                var order = _orderRepository.GetOrderById(id);
                return new OkObjectResult(order);
            }
         // POST: api/Order
        [HttpPost]
            public IActionResult Post([FromBody] Order order)
            {
                using (var scope = new TransactionScope())
                {
                    _orderRepository.InsertOrder(order);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
                }
            }
            // PUT: api/Order/5
            [HttpPut("{id}")]
            public IActionResult Put([FromBody] Order order)
            {
                if (order != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _orderRepository.UpdateOrder(order);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }
            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int OrderId)
            {
                _orderRepository.DeleteOrder(OrderId);
                return new OkResult();
            }
        }
    }

