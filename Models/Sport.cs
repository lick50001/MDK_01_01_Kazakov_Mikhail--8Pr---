using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Kazakov.Models
{
    public class Sport:Shop
    {
        public string Size { get; set; }

        public Sport(int Id, string Name, int Price, string Size) : base(Id, Name, Price) {
            this.Size = Size;
        }
    }
}
