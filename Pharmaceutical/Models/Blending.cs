using System.ComponentModel.DataAnnotations;

namespace Pharmaceutical.Models
{
    public class Blending
    {
        [Key]
        public int BlendingID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string BlendingImage { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string TypeOfBlending { get; set; }
        [Required]
        public string MixingSpeed { get; set; }
        [Required]
        public string MixingTime { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public string length { get; set; }
        [Required]
        public string Width { get; set; }
        [Required]
        public string Height { get; set; }
    }
}
