using System.ComponentModel.DataAnnotations;

namespace DatabaseAPI.Models
{
    public class Window
    {
        [Key]
        public int WindowId { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }

        public List<SubElement> SubElements { get; set; }
    }
}
