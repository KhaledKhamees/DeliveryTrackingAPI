using DeliveryTrackingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryStaffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeliveryStaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryStaff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryStaff>>> GetDeliveryStaff()
        {
            return await _context.DeliveryStaff.ToListAsync();
        }

        // POST: api/DeliveryStaff
        [HttpPost]
        public async Task<ActionResult<DeliveryStaff>> PostDeliveryStaff(DeliveryStaff deliveryStaff)
        {
            _context.DeliveryStaff.Add(deliveryStaff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryStaff", new { id = deliveryStaff.Id }, deliveryStaff);
        }
    }
}
