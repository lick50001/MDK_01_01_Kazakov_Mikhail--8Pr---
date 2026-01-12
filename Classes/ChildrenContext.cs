using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_Kazakov.Interfaces;
using Shop_Kazakov.Models;

namespace Shop_Kazakov.Classes
{
    public class ChildrenContext: ChildrenContext, IContext
    {
        public ChildrenContext() { }
        public ChildrenContext(int id, string Name, int Price, int Age, int IdShop)
        {

        }

        public List<object> All()
        {
            List<object> allShop = new List<object>();
            List<object> allChildren = new List<object>();
            OleDbConnection conn = Common.DBConnection.Connection();
            OleDbDataReader childrenData = Common.DBConnection.Query("Select * From [Детские вещи]", conn);
            while (childrenData.Read() )
            {
                ShopContext ShopElement = allShop.Find(x => (x as ShopContext).Id == childrenData.GetInt32(2)) as ShopContext;
                ChildrenContext newChildren = new ChildrenContext(
                    ShopElement.Id,
                    ShopElement.Name,
                    ShopElement.Price,
                    childrenData.GetInt32(1),
                    childrenData.GetInt32(2)
                    );
                allChildren.Add(newChildren);
            }
            Common.DBConnection.CloseConnection(conn);

            return allChildren;
        }

        public void Save(bool Update = false)
        {

        }
    }
}
