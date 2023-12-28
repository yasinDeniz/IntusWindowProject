using System.ComponentModel.DataAnnotations;

//it's for the showing db
namespace SalesOrder.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [MinLength(1)]
        public string Name { get; set; }
        [MinLength(1)]
        public string State { get; set; }
        [MinLength(1)]
        public List<WindowViewModel>? Windows { get; set; }
    }

    public class WindowViewModel
    {
        public int WindowId { get; set; }
        [MinLength(1)]
        public string Name { get; set; }
        [MinLength(1)]
        public int QuantityOfWindows { get; set; }
        [MinLength(1)]
        public int TotalSubElements { get; set; }
        [MinLength(1)]
        public int OrderId { get; set; }
        public List<SubElementViewModel>? SubElements { get; set; }
    }

    public class SubElementViewModel
    {
        public int SubElementId { get; set; }
        [MinLength(1)]
        public int Element { get; set; }
        [MinLength(1)]
        public string Type { get; set; }
        [MinLength(1)]
        public int Width { get; set; }
        [MinLength(1)]
        public int Height { get; set; }
        [MinLength(1)]
        public int WindowId { get; set; }
    }

}
