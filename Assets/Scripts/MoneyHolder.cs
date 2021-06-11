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
        if (losses < Amount)
            Amount -= losses;
        else
            Amount = 0;
    }
    public static void Add(decimal earnings)
    {
        Amount += earnings;
    }
}

