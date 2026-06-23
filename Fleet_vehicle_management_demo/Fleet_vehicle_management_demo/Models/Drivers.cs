namespace Fleet_vehicle_management_demo.Models
{
    public class Drivers
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }

        public ICollection<MaintainenceRecords>? MaintainenceRecords { get; set; }

    }
}
