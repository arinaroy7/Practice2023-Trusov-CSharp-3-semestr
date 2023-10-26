//работа с базой данных. Завести базу данных с 2 таблицами, заполнить ее данными, после чего вывести консоль для каждого пользователя сумму по его заказам.Список вывести на экран
//в базе данных: НП-null, ПК-первичный ключ, АИ-значение в этом столбце автоматически будет ув, У-уникальное значение
//orders - заказы
using Microsoft.Data.Sqlite;
using Dapper;

//string connectionString = "Data Source=C:\\Users\arina\\Desktop\\Учеба\\Учеба 2 курс УдГУ\\Андрей Серг с#\\Базы данных\\people.db";
//код, который работает с методами и базой данных
//посомтреть примеры, как выглядат запросы sql group by sum
string connectionString = "Data Source=C:\\Users\\arina\\Desktop\\Учеба\\Учеба 2 курс УдГУ\\Андрей Серг с#\\Базы данных\\people.db";

//Заполнение таблиц базы данных 
using (var connection = new SqliteConnection(connectionString))
{
    connection.Open();

    connection.Execute("INSERT INTO users (Login, Password) VALUES (@Login, @Password)",
        new { Login = "Vasya", Password = "123" });
    connection.Execute("INSERT INTO users (Login, Password) VALUES (@Login, @Password)",
        new { Login = "Arina", Password = "1234" });

    connection.Execute("INSERT INTO orders (Name, Price, UserId) VALUES (@Name, @Price, @UserId)",
        new { Name = "Блин", Price = 10, UserId = 1 });
    connection.Execute("INSERT INTO orders (Name, Price, UserId) VALUES (@Name, @Price, @UserId)",
        new { Name = "Блин с мясом", Price = 20, UserId = 2 });
    connection.Execute("INSERT INTO orders (Name, Price, UserId) VALUES (@Name, @Price, @UserId)",
        new { Name = "Блин с дыркой", Price = 5, UserId = 1 });
    connection.Execute("INSERT INTO orders (Name, Price, UserId) VALUES (@Name, @Price, @UserId)",
        new { Name = "Блин со сметаной", Price = 20, UserId = 2 });
}
