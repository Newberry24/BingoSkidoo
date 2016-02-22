using System;

public class Point
{
    private int x, y;
    public int X
    {
        get { return x; }
        set { x=value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }
    public Point(int startX, int startY)
    {
        x = startX;
        y = startY;
    }
}

