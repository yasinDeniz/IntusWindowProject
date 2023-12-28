using System.ComponentModel.DataAnnotations;

namespace DatabaseAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public List<Window> Windows { get; set; }
    }
}
