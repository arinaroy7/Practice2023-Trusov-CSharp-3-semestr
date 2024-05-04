/*коллекции типа Treasure и Weapon и Armor
Treasure[] inventory = 
{
    new Treasure("Алмаз", 1000),
    new Treasure("Веточка", 1), //treasure - тип 
    new Weapon("Меч", 100, 15), //15 - доп урон для меча
    new Armor("Шлем", 50, 5),
    new Armor("Броня", 75, 15),

};

foreach(Treasure t in inventory)
{
    Console.WriteLine(t.GetDesc()); //вызов с помощью виртуальной функции
}

foreach(var t in inventory)
{
    if (t is Armor a)
    {
        Console.WriteLine(a.GetDesc());
    }
    else if (t is Weapon w)
    {
        Console.WriteLine(w.GetDesc());
    }
    else
    {
        Console.WriteLine(t.GetDesc());
    }
}

Написать подобную программу - базовый класс и два потомка, которые расширяют эти классы 
Есть базовый класс еда, есть базовый класс со сроком годности и испорченная еда */

Products[] fridge =
{
    new Products("Свёкла", 10),
    new Products("Морковка", 7), 
    new Fruits("Апельсины", 5, 1), //5 - количество
    new Fruits("Мандарины", 20, 3),
    new Meat("Котлеты", 5, 1),
    new Meat("Курица", 1, 7),
};

foreach(var t in fridge)
{
    Console.WriteLine(t.GetDesc());
}