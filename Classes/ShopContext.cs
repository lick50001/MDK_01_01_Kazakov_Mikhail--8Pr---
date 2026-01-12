using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_Kazakov.Interfaces;

namespace Shop_Kazakov.Models
{
    public class ShopContext: Shop, IContext
    {
        public ShopContext(int Id, string Name, int Price) : base(Id, Name, Price) { }
        public static List<object> AllItems()
        {
            List<object> allItems = new List<object>();
            allItems.Add(new Children("Интерактив", 2200, 3));
            allItems.Add(new Children("Кактус", 894, 6));
            allItems.Add(new Children("Кошка подушка", 1754, 6));
            allItems.Add(new Sport("Споривный костюм", 4891, "S"));
            allItems.Add(new Sport("Водяной мяч", 512, "61-63 см"));
            allItems.Add(new Sport("Набор для гольфа", 3950, "600*800 мм"));
            allItems.Add(new Electronik("Самокат", 45891, 5000, 120));
            allItems.Add(new Electronik("Велосипед", 15152, 15210, 80));
            allItems.Add(new Electronik("Гироскутер", 73950, 4500, 40));

            return allItems;
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void Save(bool Update = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
