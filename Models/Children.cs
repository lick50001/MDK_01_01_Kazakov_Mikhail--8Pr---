using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Kazakov.Models
{
    public class Children:Shop
    {
        public int Age { get; set; }
        public int IdShop { get; set; }
        public Children(string Name, int Price, int Age, int IdShop) : base(Id, Name, Price) {
            this.Age = Age;
            this.IdShop = IdShop;
        }
    }
}
