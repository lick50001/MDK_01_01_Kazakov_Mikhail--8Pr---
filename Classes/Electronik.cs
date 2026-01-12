using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Kazakov.Models
{
    public class Electronik:Shop
    {
        public int BatteryCapacity { get; set; }
        public int MaxSpeed { get; set; }
        public Electronik(int Id, string Name, int Price, int BatteryCapacity, int MaxSpeed) : base(Id, Name, Price)
        {
            this.BatteryCapacity = BatteryCapacity;
            this.MaxSpeed = MaxSpeed;
        }
    }
}
