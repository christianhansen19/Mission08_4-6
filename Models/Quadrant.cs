using System.ComponentModel.DataAnnotations;

namespace Mission08_4_6.Models
{
    public class Quadrant
    {
        [Key]
        [Required]
        public int QuadrantID { get; set; }
        [Required]
        public string QuadrantName { get; set; }
    }
}