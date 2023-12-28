using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string Name { get; set; }
        [MinLength(1)]
        public string State { get; set; }

        public List<Window> Windows { get; set; }
    }
}
