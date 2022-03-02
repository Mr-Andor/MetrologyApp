using System.ComponentModel.DataAnnotations;

namespace MetrologyApp.Models
{
    public class ActualPoint
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
        [Required]
        public double Z { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
