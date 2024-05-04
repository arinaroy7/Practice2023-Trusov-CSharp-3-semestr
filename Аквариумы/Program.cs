var Box1 = new Box(new RectCollider() { top=0, left=0, width=20, height=10 });
var Box2 = new Box(new CircleCollider() { cx = 40, cy = 10, radius = 10 });

while (!EscPressed())
{
    Console.Clear();

    Box1.DrawBox();
    Box2.DrawBox();

    Box1.MoveAll();
    Box2.MoveAll();

    Thread.Sleep(250);
}

bool EscPressed()
{
    while (Console.KeyAvailable)
    {
        var ki = Console.ReadKey();
        if (ki.Key == ConsoleKey.Escape)
            return true;
    }
    return false;
}
