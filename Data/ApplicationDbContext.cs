using Microsoft.EntityFrameworkCore;
using DeliveryTrackingAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<DeliveryStaff> DeliveryStaff { get; set; }
    public DbSet<Location> Locations { get; set; }
}
