/*class Treasure 
{
    public string Name;

    public int Cost { get; }

    public int Const;
    public virtual string GetDesc() => $"{Name}, {Cost} gold"; //базовый класс

    public Treasure(string name, int cost)
    {
        Name = name;
        Cost = cost;
    }
}

class Weapon : Treasure //наследование класса Treasure
{
    public int Damage;
    public override string GetDesc() => $"{Name}, {Cost} gold, {Damage} dmg";

    public Weapon(string name, int cost, int dmg) : base(name, cost) // : base ... вызов конструктора из предка
    {
        Damage = dmg; 
    }
}

class Armor : Treasure //наследование класса Treasure
{
    public int Damage;

    public Armor(string name, int cost, int dmg) : base(name, cost) // : base ... вызов конструктора из предка
    {
        Damage = dmg; 
    }
}*/

class Products
{
    public string Name;
    public int Cost { get; }
    public int Const;
    public virtual string GetDesc() => $"{Name}, {Cost} kilogram";

    public Products(string name, int cost)
    {
        Name = name;
        Cost = cost;
    } 
}
class Fruits : Products
{
    public int Damage;
    public override string GetDesc() => $"{Name}, {Cost} kilogram, {Damage}";

    public Fruits(string name, int cost, int dmg) : base(name, cost)
    {
        Damage = dmg; 
    } 
}
class Meat : Products
{
    public int Damage;

    public Meat(string name, int cost, int dmg) : base(name, cost)
    {
        Damage = dmg; 
    }
}