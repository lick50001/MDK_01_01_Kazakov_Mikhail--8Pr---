using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Kazakov.Classes
{
    public class RepoItems
    {
        public static List<object> AllItems()
        {
            List<object> allItems = new List<object>();
            allItems.Add(new Children("интерактив", 2200, 3));
            allItems.Add(new Children("Кактус", 894, 6));
            allItems.Add(new Children("Кошка подушка", 1754, 6));
            allItems.Add(new Sport("Споривный костюм", 4891, "S"));
            allItems.Add(new Sport("Водяной мяч", 512, "61-63 см"));
            allItems.Add(new Sport("Набор для гольфа", 3950, "600*800 мм"));

            return allItems;
        }
    }
}
