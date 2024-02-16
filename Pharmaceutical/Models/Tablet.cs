namespace Pharmaceutical.Models
{
    public class Tablet
    {
        public int TabletID { get; set; }
         
        public string Name { get; set;}

        public string ModelNumber { get; set;}
        public string TabletImage { get; set; }

        public string Dies { get; set;}

        public string MaxPressure { get; set;}

        public string MaxDiameter { get;set;}

        public string MaxDepthOfFill { get; set;}
        
        public string ProductionCapacity { get; set;}

        public string MachineSize { get; set;}

        public string Netweight { get; set;}

    }
}
