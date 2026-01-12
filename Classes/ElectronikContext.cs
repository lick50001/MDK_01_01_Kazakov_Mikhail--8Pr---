using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Shop_Kazakov.Interfaces;
using Shop_Kazakov.Models;

namespace Shop_Kazakov.Classes
{
    public class ElectronikContext : Electronik, IContext
    {


        public ElectronikContext(int Id, string Name, int Price, int BatteryCapacity, int MaxSpeed)
            : base(Id, Name, Price, BatteryCapacity, MaxSpeed) { }

        public List<object> All()
        {
            return GetAllItems();
        }

        public static List<object> GetAllItems()
        {
            var allElectronik = new List<object>();

            try
            {
                using (var conn = Common.DBConnection.Conn())
                {
                    // Таблица "Электроника" с полями:
                    // Код, Код товара, Ёмкость аккумулятора, Максимальная скорость
                    var cmd = new OleDbCommand(@"
                    SELECT e.[Код], t.[Наименование], t.[Стоимость], e.[Ёмкость аккумулятора], e.[Максимальная скорость]
                    FROM [Электроника] e
                    INNER JOIN [Товар] t ON e.[Код товара] = t.[Код]", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                string name = reader.IsDBNull(1) ? "Без названия" : reader.GetString(1);
                                int price = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                int battery = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                                int speed = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

                                allElectronik.Add(new ElectronikContext(id, name, price, battery, speed));
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
                Console.WriteLine($"Ошибка загрузки электроники: {ex.Message}");
            }

            return allElectronik;
        }

        public void Delete() => throw new NotImplementedException();
        public void Save(bool Update = false) => throw new NotImplementedException();
    }
}