using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
    public class SubElement
    {
        [Key]
        public int SubElementId { get; set; }
        [Required]
        public int Element { get; set; }
        [MinLength(1)]
        public string Type { get; set; }
        [MinLength(1)]
        public int Width { get; set; }
        [MinLength(1)]
        public int Height { get; set; }
    }
}
