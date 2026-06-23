namespace Fleet_vehicle_management_demo.Models
{
    public class Vehicles
    {


    public int VehicleId { get; set; }
    public string VehicleNumber { get; set; } = string.Empty;
    public string VehicleType { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int PurchaseYear { get; set; }
    public bool IsActive { get; set; }
        public ICollection<MaintainenceRecords>? MaintainenceRecord { get; set; }

    }
}
