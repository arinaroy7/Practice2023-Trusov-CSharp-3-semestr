using System.Security.Cryptography.X509Certificates;

class Fish : Point
{
    public int dx;
    public int dy;
    
    public override void Draw()
    {
        if (dx<0)
            Print(x,y,"<')))><");
        else
            Print(x,y,"><((('>");
    }

    public override void Move(Collider collider)
    {
        var nx = x + dx;
        var ny = y + dy;

        if (collider.IsCollide(nx,ny))
        {
            dx = -dx;
            dy = -dy;
        }
        x += dx;
        y += dy;
    }
}


