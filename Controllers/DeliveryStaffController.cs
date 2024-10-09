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
        // Delete : api/DeliveryStaff
        [HttpDelete]
        public async Task<ActionResult<DeliveryStaff>> DeleteDeliveryStaff(int id)
        {
            var delivaryFromDb = _context.DeliveryStaff.FirstOrDefault(x => x.Id == id);
            if (id <= 0 || delivaryFromDb == null)
            {
                return BadRequest();
            }
            _context.DeliveryStaff.Remove(delivaryFromDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // Update : api/DeliveryStaff
        [HttpPatch]
        public async Task<ActionResult<DeliveryStaff>> UpdateDeliveryStaff(int id, DeliveryStaff updatedStaff)
        {
            var delivaryFromDb = await _context.DeliveryStaff.FindAsync(id);
            if (delivaryFromDb == null)
            {
                return NotFound();
            }

            delivaryFromDb.Name = updatedStaff.Name ?? delivaryFromDb.Name;
            delivaryFromDb.PhoneNumber = updatedStaff.PhoneNumber ?? delivaryFromDb.PhoneNumber;

            _context.DeliveryStaff.Update(delivaryFromDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
