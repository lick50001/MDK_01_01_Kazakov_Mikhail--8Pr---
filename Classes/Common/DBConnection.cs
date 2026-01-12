using System;
using System.Data.OleDb;

namespace Shop_Kazakov.Classes.Common
{
    public class DBConnection
    {
        // Убедитесь, что путь правильный
        public static readonly string Path = @"C:\Users\student-a502.PERMAVIAT\Source\Repos\MDK_01_01_Kazakov_Mikhail--8Pr---\Shop.accdb";

        public static OleDbConnection Conn()
        {
            try
            {
                // Пробуем разные провайдеры
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path};Persist Security Info=False;";
                // Альтернативная строка подключения:
                // string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path};";

                var connection = new OleDbConnection(connectionString);
                connection.Open();
                Console.WriteLine("Подключение успешно!");
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
                throw;
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = Conn())
                {
                    return conn.State == System.Data.ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}