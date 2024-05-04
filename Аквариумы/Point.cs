using System;
using System.Collections.Generic;

class Point
{
    public int x;
    public int y;

    public virtual void Draw() { }

    public virtual void Move(Collider collider) { }

    protected void Print(int x, int y, string s) 
    {
        if (x >= 0 && x < Console.BufferWidth && y >= 0 && y < Console.BufferHeight)
        {
        Console.SetCursorPosition(x, y);
        Console.Write(s);
        }
        
    }
}
