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
        public ShopContext()
        {
        }

        public ShopContext(int Id, string Name, int Price) : base(Id, Name, Price) { }
        public List<object> All()
        {
            List<object> allItems = new List<object>();
            // Здесь Id и IdShop могут быть одинаковыми для тестовых данных
            allItems.Add(new Children(1, "Интерактив", 2200, 3, 1));
            allItems.Add(new Children(2, "Кактус", 894, 6, 2));
            allItems.Add(new Children(3, "Кошка подушка", 1754, 6, 3));
            allItems.Add(new Sport(4, "Споривный костюм", 4891, "S"));
            allItems.Add(new Sport(5, "Водяной мяч", 512, "61-63 см"));
            allItems.Add(new Sport(6, "Набор для гольфа", 3950, "600*800 мм"));
            allItems.Add(new Electronik(7, "Самокат", 45891, 5000, 120));
            allItems.Add(new Electronik(8, "Велосипед", 15152, 15210, 80));
            allItems.Add(new Electronik(9, "Гироскутер", 73950, 4500, 40));

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
