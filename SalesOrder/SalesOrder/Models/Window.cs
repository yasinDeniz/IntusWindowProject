using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
    public class Window
    {
        [Key]
        public int WindowId { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }

        public List<SubElement> SubElements { get; set; }
    }
}
