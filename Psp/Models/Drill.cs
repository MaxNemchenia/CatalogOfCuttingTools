using System.ComponentModel.DataAnnotations;

namespace Psp.Models
{
    public class Drill
    {
        [Required(ErrorMessage = "Please enter Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Diametr")]
        public int Diametr { get; set; }

        [Required(ErrorMessage = "Please enter TotalLength")]
        public int TotalLength { get; set; }

        [Required(ErrorMessage = "Please enter WorkLength")]
        public int WorkLength { get; set; }

        [Required(ErrorMessage = "Please enter Standart")]
        public string Standart { get; set; }
    }
}