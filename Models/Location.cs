using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryTrackingAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int DeliveryStaffId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        [ForeignKey(nameof(DeliveryStaffId))]
        public DeliveryStaff DeliveryStaff { get; set; }
    }
}
