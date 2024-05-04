class Box
{
    Collider collider;
    Point[] items;

    public Box(Collider collider)
    {
        this.collider = collider;

        items = new Point[]
        {
            new Fish()   { dx = Random.Shared.Next(-2,3), dy = Random.Shared.Next(-1,2) },
            new Fish()   { dx = Random.Shared.Next(-2,3), dy = Random.Shared.Next(-1,2)  },
            new Bubble() { speed = Random.Shared.Next(-3,0)},
        };

        foreach(var i in items)
        {
            while(true)
            {
                int x = Random.Shared.Next(0,1000);
                int y = Random.Shared.Next(0,1000);
                if (!collider.IsCollide(x,y))
                {
                    i.x = x;
                    i.y = y;
                    break;
                }
            }
        }
    }

    public void DrawBox()
    {
        foreach (var i in items)
            i.Draw();
    }

    public void MoveAll()
    {
        foreach (var i in items)
            i.Move(collider);
    }
}