using System.Collections.Generic;
using System.Linq;

namespace Store.Web.Models
{
    public class Cart
    {
        public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>();
        public decimal Price { get; set; }
        public int Amount => Items.Values.Sum();
    }
}
