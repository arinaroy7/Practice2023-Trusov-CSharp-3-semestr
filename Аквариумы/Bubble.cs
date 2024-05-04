class Bubble : Point
{
    public int speed;

    public override void Draw()
    {
        Print(x, y, "o");
    }

    public override void Move(Collider collider)
    {
        if (!collider.IsCollide(x,y+speed))
            y += speed;
    }
}