using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrdersController(AppDbContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        [Route("GetOrders")]
        public List<Order> GetOrders()
        {
            return _context.Order.ToList();
        }
        [HttpGet]
        [Route("GetOrder")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order.Include(o => o.Windows).ThenInclude(w => w.SubElements).FirstOrDefaultAsync(x => x.OrderId == id);

            return order;
        }

        [HttpPost]
        [Route("AddOrder")]
        public string AddOrder(Order order)
        {
            string response = string.Empty;
            _context.Order.Add(order);
            _context.SaveChanges();
            return response;
        }

        [HttpPut]
        [Route("UpdateOrder/{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            if (id != updatedOrder.OrderId)
            {
                return BadRequest("Invalid order ID");
            }

            var existingOrder = await _context.Order.Include(o => o.Windows).ThenInclude(w => w.SubElements).FirstOrDefaultAsync(x => x.OrderId == id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.Name = updatedOrder.Name;
            existingOrder.State = updatedOrder.State;

            foreach (var updatedWindow in updatedOrder.Windows)
            {
                if (updatedWindow.WindowId==0)
                {
                    existingOrder.Windows.Add(updatedWindow);
                }
                else
                {
                    var existingWindow = existingOrder.Windows.FirstOrDefault(w => w.WindowId == updatedWindow.WindowId);

                    if (existingWindow != null)
                    {
                        existingWindow.Name = updatedWindow.Name;
                        existingWindow.QuantityOfWindows = updatedWindow.QuantityOfWindows;

                        foreach (var updatedSubElement in updatedWindow.SubElements)
                        {
                            if (updatedSubElement.SubElementId == 0)
                            {
                                existingWindow.SubElements.Add(updatedSubElement);
                            }
                            else
                            {
                                var existingSubElement = existingWindow.SubElements.FirstOrDefault(s => s.SubElementId == updatedSubElement.SubElementId);

                                if (existingSubElement != null)
                                {
                                    existingSubElement.Type = updatedSubElement.Type;
                                    existingSubElement.Width = updatedSubElement.Width;
                                    existingSubElement.Height = updatedSubElement.Height;
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                    }
                }
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var existingOrder = await _context.Order.Include(o => o.Windows).ThenInclude(w => w.SubElements).FirstOrDefaultAsync(x => x.OrderId == id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            foreach (var existingWindow in existingOrder.Windows.ToList())
            {
                foreach (var existingSubElement in existingWindow.SubElements.ToList())
                {
                    _context.SubElement.Remove(existingSubElement);
                }

                _context.Window.Remove(existingWindow);
            }

            _context.Order.Remove(existingOrder);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
