using System;

public static class MoneyHolder
{
    private static decimal amount = 10;
    public static decimal Amount
    {
        get { return amount; }
        set { amount = value; }
    }
    public static void Deduct(decimal losses)
    {
        Amount -= losses;
    }
    public static void Add(decimal earnings)
    {
        Amount += earnings;
    }
}

