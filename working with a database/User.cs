using Microsoft.Data.Sqlite;
using Dapper;
using System;

partial class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=C:\\Users\\arina\\Desktop\\Учеба\\Учеба 2 курс УдГУ\\Андрей Серг с#\\Базы данных\\people.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            

        }    
    }


    /*static bool CheckLogin(string login, string pass)

    {
        using (var conn = new SqliteConnection(connectionString))
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE Login = @Login AND Password = @Password";
            return conn.QueryFirstOrDefault<int>(sql, new { Login = login, Password = pass }) > 0;
        }
    }

    static long CreateUser(users user)
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            string sql = "INSERT INTO Users (Login, Password) VALUES (@Login, @Password); SELECT last_insert_rowid()";
            return conn.QueryFirstOrDefault<long>(sql, user);
        }
    }

    static void UpdateUser(User user)
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            string sql = "UPDATE Users SET Login = @Login, Password = @Password WHERE Id = @Id";
            conn.Execute(sql, user);
        }
    }

    static void DeleteUser(int id)
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            string sql = "DELETE FROM Users WHERE Id = @Id";
            conn.Execute(sql, new { Id = id });
        }
    }*/
}
