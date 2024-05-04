class Snail : Point
{
    public int dx;

    public override void Draw()
    {
        Print(x, y, "@");
    }

    public override void Move(Collider collider)
    {
        int nx = x+dx;

        if (collider.IsCollide(nx,y)) dx = -dx;

        x += dx; 
    }
}
