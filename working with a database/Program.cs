//работа с базой данных. Завести базу данных с 2 таблицами, заполнить ее данными, после чего вывести консоль для каждого пользователя сумму по его заказам.Список вывести на экран
//в базе данных: НП-null, ПК-первичный ключ, АИ-значение в этом столбце автоматически будет ув, У-уникальное значение
//orders - заказы

using System;
using Microsoft.Data.Sqlite;
using Dapper;
using YourNamespace;

//string connectionString = "Data Source=C:\\Users\arina\\Desktop\\Учеба\\Учеба 2 курс УдГУ\\Андрей Серг с#\\Базы данных\\people.db";
//код, который работает с методами и базой данных
//посомтреть примеры, как выглядат запросы sql group by sum

namespace YourNamespace {
    class Program
    {
        static void Main(string[] args)
        {
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

                //SQL - запрос u.UserId-идентификатор пользователя из таблицы users
                //SUM(o.Price) AS TotalPrice - суммирует столбец Price из таблицы orders -> результат в TotalPrice

                var query = @"
                    SELECT
                        u.[ID заказа] AS UserId, 
                        u.Login,
                        SUM(o.Price) AS TotalPrice
                    FROM users u
                    LEFT JOIN orders o ON u.[ID заказа] = o.UserID
                    GROUP BY u.[ID заказа], u.Login
                ";

                var usersWithTotalPrice = connection.Query<UserWithTotalPrice>(query);

                //вывод данных в консоль
                foreach (var user in usersWithTotalPrice)
                {
                    Console.WriteLine($"User: {user.Login}, Total Price of Orders: {user.TotalPrice}");
                }
            }

        }
    }

}

/* пара за 26 октября

транзакции - несколько запросов в базу данных, которые должны быть выполнены или не выполнены
есть игра, у игроков есть возможность торговать. 1 таблица players - 2 колонки  id и gold 
Items (колонка, что продаем) - id(принадлежности игроку шапки или кепки) , pid, cost(стоимость предметов, за сколько продаем), name (шапка, кепка)
первый игрок покупает шапку  увторого игрока 

*Pid-player id - > идентификатор, кому принадлежит предмет 
*В SQL запросы все значения передаем через параметры

SELECT id, gold FROM Players WHERE id=1 OR id-2
SELECT cost FROM Items WHERE id=1 - > занимаемся перекладыванием денег
UPDATE  Players SET gold=25 WHERE id=1 -> обновляем количество золота, ум его
UPDATE  Players SET gold=25 WHERE id=2
UPDATE Itams SET pid=1 WHERE id=1 

В единицу времени будет одна покупка, одна продажа 
*Почитать про транзкации var tx = ... (транзакция открыта) .... tx.Commit(); (Транзакция закрыта и применина)
tx.RollBack; - откатить назад транзакцию  -> вернет золото обратно, если предмет был куплен другим человеком ранее

Если что-то идет не так генерируем исключение командой throw (она прыгает к ближайшему catch) -> throw new Exception("Недостаточно денег!");

ДЗ: 26.10.23 на транзакции. У нас уже есть программа, которая выводит сумму по заказам конкретного игрока. Добавить еще одну функцию, которая
переводит средства с одного заказа на другой (перевод с карты на карту) с проверками - > стоимость заказа не станет отриц, необходимо засунуть в транкзацию 
*/
