using System;
using System.Collections.Generic;
using UnityEngine;

public class WinningCombo
{
    private List<Point> coordinates;

    //Default constructor that does nothing.
    public WinningCombo() { }

    //constructor that sets up the coordinates for the winning set.
    public WinningCombo(List<Point> spaceCoordinates)
    {
        coordinates = spaceCoordinates;
    }

    //Used to determine if the winning combo is fulfilled.
    public bool checkWinningCombo(Card card, List<BingoNumber> calledNumbers)
    {
        foreach(Point coordinate in coordinates){
          //  Debug.Log("(" + coordinate.X + "," + coordinate.Y + ")");
            //return false if the corresponding number is not called
           // Debug.Log(card.spaces[coordinate.X* 5  + coordinate.Y].Number+" "+
             //   calledNumbers[card.spaces[coordinate.X* 5  + coordinate.Y].Number-1].Number+
             //   calledNumbers[card.spaces[coordinate.X* 5  + coordinate.Y].Number - 1].Called);
            if (!(card.spaces[coordinate.X*5+coordinate.Y].freeSpace)
                && !(calledNumbers[card.spaces[coordinate.X*5+coordinate.Y].Number-1].Called))
				return false;
           }
        //return true if all of the corresponding numbers are called.
        return true;
    }

    //Checks if the point in question is a part of the set of winning points.  Used for window display
    public bool CheckPointInSet(Point square)
    {
        foreach(Point coordinate in coordinates){
            if(square.X == coordinate.X && square.Y == coordinate.Y)
                return true;
        }
        return false;
    }

}
