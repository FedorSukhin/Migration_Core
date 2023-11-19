using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration_Core.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //заменяем decimal на string
        //public decimal Price { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Description} - {Price}";
        }
    }
}
