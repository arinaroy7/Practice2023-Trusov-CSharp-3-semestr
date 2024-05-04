class Collider
{
    public virtual bool IsCollide(int x, int y) {return false;}
}

class RectCollider : Collider
{
    public int top;
    public int left;
    public int width;
    public int height;
    public override bool IsCollide(int x, int y)
    {
        if (x<left || x>=left+width) return true;
        if (y<top || y>=top+height) return true;
        return false;
    }
}

class CircleCollider : Collider
{
    public int cx;
    public int cy;
    public int radius;
    public override bool IsCollide(int x, int y)
    {
        double dist2 = (cx-x)*(cx-x) + (cy-y)*(cy-y);
        if (dist2 > radius*radius) return true;
        return false;
    }
}