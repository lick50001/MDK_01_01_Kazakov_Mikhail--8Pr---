using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Shop_Kazakov.Interfaces;
using Shop_Kazakov.Models;

namespace Shop_Kazakov.Classes
{
    public class SportContext : Sport, IContext
    {


        public SportContext(int Id, string Name, int Price, string Size)
            : base(Id, Name, Price, Size) { }

        public List<object> All()
        {
            return GetAllItems();
        }

        public static List<object> GetAllItems()
        {
            var allSport = new List<object>();

            try
            {
                using (var conn = Common.DBConnection.Conn())
                {
                    // Таблица "Спортивный инвентарь" с полями:
                    // Код, Код товара, Размер
                    var cmd = new OleDbCommand(@"
                    SELECT s.[Код], t.[Наименование], t.[Стоимость], s.[Размер]
                    FROM [Спортивный инвентарь] s
                    INNER JOIN [Товар] t ON s.[Код товара] = t.[Код]", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                string name = reader.IsDBNull(1) ? "Без названия" : reader.GetString(1);
                                int price = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                string size = reader.IsDBNull(3) ? "Не указан" : reader.GetString(3);

                                allSport.Add(new SportContext(id, name, price, size));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка чтения записи: {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки спортивных товаров: {ex.Message}");
            }

            return allSport;
        }

        public void Delete() => throw new NotImplementedException();
        public void Save(bool Update = false) => throw new NotImplementedException();
    }
}