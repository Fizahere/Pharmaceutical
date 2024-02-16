namespace Pharmaceutical.Models
{
    public class UsedEquipment
    {
        public int UsedEquipmentID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string UsedEquipmentImage { get; set; }
        public string Manufacturer {  get; set; }
        public string Condition { get; set; }
        public string PreviousUsage { get; set; }
        public string ReasonsForSelling { get; set; }
    }
}
