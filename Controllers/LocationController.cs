using DeliveryTrackingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Location/{staffId}
        [HttpGet("{staffId}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetStaffLocation(int staffId)
        {
            return await _context.Locations
                .Where(l => l.DeliveryStaffId == staffId)
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();
        }

        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffLocation", new { staffId = location.DeliveryStaffId }, location);
        }
    }
}
