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
                /*connection.Open();

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
                */
                
                var query = @"
                    SELECT
                        u.[ID] AS UserId, 
                        u.Login,
                        SUM(o.Price) AS TotalPrice
                    FROM users u
                    LEFT JOIN orders o ON u.[ID] = o.UserID
                    GROUP BY u.[ID], u.Login
                ";

                var usersWithTotalPrice = connection.Query<UserWithTotalPrice>(query);

                foreach (var user in usersWithTotalPrice)
                {
                    Console.WriteLine($"User: {user.Login}, Total Price of Orders: {user.TotalPrice}");
                }

                Console.WriteLine("Введите команду (transfer для перевода средств):");
                string command = Console.ReadLine();

                if (command == "transfer")
                {
                    Console.WriteLine("Введите ID покупателя:");
                    int buyerUserId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите ID продавца:");
                    int sellerUserId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите стоимость товара:");
                    int itemCost = int.Parse(Console.ReadLine());

                    //TransferFunds(connection, buyerUserId, sellerUserId, itemCost);
            }

        }
    }

        static void TransferFunds(SqliteConnection connection, int buyerUserId, int sellerUserId, int itemCost)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    //проверка средств покупателя 
                    int buyerBalance = connection.QueryFirstOrDefault<int>("SELECT Balance FROM Users WHERE ID = @UserId", new { UserId = buyerUserId });

                    if (buyerBalance >= itemCost)
                    {
                        connection.Execute("UPDATE Users SET Balance = Balance - @Cost WHERE ID = @UserId", new { Cost = itemCost, UserId = buyerUserId });

                        connection.Execute("UPDATE Users SET Balance = Balance + @Cost WHERE ID = @UserId", new { Cost = itemCost, UserId = sellerUserId });

                        transaction.Commit(); //успешная тарнзакция

                        Console.WriteLine("Перевод средств выполнен успешно.");
                    }
                    else 
                    {
                        Console.WriteLine("Недостаточно средств у покупателя.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    transaction.Rollback(); //ошибка  в транзакции
                }
                
            }
        }
    }
}

/* пара за 26 октября

транзакции - несколько запросов в базу данных, которые должны быть выполнены или не выполнены

*Pid-player id - > идентификатор, кому принадлежит предмет 
*В SQL запросы все значения передаем через параметры

SELECT id, gold FROM Players WHERE id=1 OR id-2
SELECT cost FROM Items WHERE id=1 - > занимаемся перекладыванием денег
UPDATE  Players SET gold=25 WHERE id=1 -> обновляем количество золота, ум его
UPDATE  Players SET gold=25 WHERE id=2
UPDATE Itams SET pid=1 WHERE id=1 

tx.RollBack; - откатить назад транзакцию  -> вернет золото обратно, если предмет был куплен другим человеком ранее

Если что-то идет не так генерируем исключение командой throw (она прыгает к ближайшему catch) -> throw new Exception("Недостаточно денег!");

ДЗ: на транзакции. У нас уже есть программа, которая выводит сумму по заказам конкретного игрока. Добавить еще одну функцию, которая
переводит средства с одного заказа на другой (перевод с карты на карту) с проверками - > стоимость заказа не станет отриц, необходимо засунуть в транкзацию 

SQL запросы: 

1. Для добавления нового столбца 

CREATE TABLE Users (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Login TEXT NOT NULL,
    Balance INTEGER NOT NULL
);

2. Изменение имени столбца

ALTER TABLE users
RENAME COLUMN "ID заказа" TO "ID пользователя";

3. 
*/
