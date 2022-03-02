using System.ComponentModel.DataAnnotations;

namespace MetrologyApp.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        public double avgPointX { get; set; }
        public double avgPointY { get; set; }
        public double avgPointZ { get; set; }

        public double deviation { get; set; }

        [Required]
        public int NominalPointId { get; set; }
        [Required]
        public int ActualPointId { get; set; }


    }
}
