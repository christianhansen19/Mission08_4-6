using System.ComponentModel.DataAnnotations;

namespace Mission08_4_6.Models
{
    public class FormResponse
    {
        // Required Fields
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }

        // Optional Fields
        public string DueDate { get; set; }
        public string Category { get; set; }
        public bool Completed { get; set; }

        // Foreign Key Relationship
        [Required]
        public int QuadrantID { get; set; } // QuadrantID from Quadrant Model
        public Quadrant Quadrant { get; set; }
    }
}