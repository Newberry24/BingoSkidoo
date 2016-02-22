using System;

public class BingoNumber
{
    private int number;
    public int Number
    {
        get { return number; }
        set { number = value; }
    }

    private bool called;
    public bool Called
    {
        get { return called; }
        set { called = value; }
    }
    //Default constructor that does nothing.
    public BingoNumber() { }

    public BingoNumber(int num)
    {
        Number = num;
        Called = false;
    }
}

