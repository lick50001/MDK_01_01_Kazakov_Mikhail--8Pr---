using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Kazakov.Classes
{
    public class Electronik:Shop
    {
        public int BatteryCapacity { get; set; }
        public int MaxSpeed { get; set; }
        public Electronik(string Name, int Price, int BatteryCapacity, int MaxSpeed) : base(Name, Price)
        {
            this.BatteryCapacity = BatteryCapacity;
            this.MaxSpeed = MaxSpeed;
        }
    }
}
