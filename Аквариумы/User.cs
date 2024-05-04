namespace YourNamespace {
    public class User
    {
        public int ID { get; set; } //идентификатор пользователя
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}

/* Пара за 26 октября

void Trade(int byerid, int sellerid, int itemid) { //функцию вызываем, когда один игрок что-то продает 
    using var conn = mew SqliteConnection("Data Source=...db");

    int byergold = conn.Query<>

    int cost 
    //проверяем хватит ли у продавца денег
    if (byergold < cost) return;

    conn.Execute("UPDATE SET gold=@gold WHERE id=@id", new{}); //
} */