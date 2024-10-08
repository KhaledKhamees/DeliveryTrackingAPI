using Microsoft.EntityFrameworkCore;
using DeliveryTrackingAPI.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<DeliveryStaff> DeliveryStaff { get; set; }
    public DbSet<Location> Locations { get; set; }
}
