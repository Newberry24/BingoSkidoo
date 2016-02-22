
using System.Collections.Generic;
using UnityEngine;

public static class WinningCombos
{
    private static List<WinningCombo> combos=new List<WinningCombo>();
    public static void Initialize()
    {
        //Set up the 32 ways to win.
        //Horizontals
        combos.Add(new WinningCombo(new List<Point>(){new Point(0,0),new Point(0,1),new Point(0,2),new Point(0,3),new Point(0,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(1,0),new Point(1,1),new Point(1,2),new Point(1,3),new Point(1,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(2,0),new Point(2,1),new Point(2,2),new Point(2,3),new Point(2,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(3,0),new Point(3,1),new Point(3,2),new Point(3,3),new Point(3,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(4,0),new Point(4,1),new Point(4,2),new Point(4,3),new Point(4,4)}));
		//Verticals                       
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,0),new Point(1,0),new Point(2,0),new Point(3,0),new Point(4,0)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,1),new Point(1,1),new Point(2,1),new Point(3,1),new Point(4,1)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,2),new Point(1,2),new Point(2,2),new Point(3,2),new Point(4,2)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,3),new Point(1,3),new Point(2,3),new Point(3,3),new Point(4,3)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,4),new Point(1,4),new Point(2,4),new Point(3,4),new Point(4,4)}));
		//Diagonals                
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,0),new Point(1,1),new Point(2,2),new Point(3,3),new Point(4,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,4),new Point(1,3),new Point(2,2),new Point(3,1),new Point(4,0)}));
		//Postage Stamps          
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,0),new Point(1,0),new Point(0,1),new Point (1,1)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,3),new Point(1,3),new Point(0,4),new Point (1,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(3,0),new Point(4,0),new Point(3,1),new Point (4,1)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(3,3),new Point(3,4),new Point(4,3),new Point (4,4)}));
		//Right Angles            
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,2),new Point(1,2),new Point(2,2),new Point(2,1),new Point(2,0)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,2),new Point(1,2),new Point(2,2),new Point(2,3),new Point(2,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(2,0),new Point(2,1),new Point(2,2),new Point(3,2),new Point(4,2)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(2,4),new Point(2,3),new Point(2,2),new Point(3,2),new Point(4,2)}));
		//Little X’s               
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,0),new Point(1,1),new Point(2,2),new Point(0,2),new Point(2,0)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,4),new Point(1,3),new Point(2,2),new Point(0,2),new Point(2,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(2,0),new Point(4,2),new Point(2,2),new Point(3,1),new Point(4,0)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(4,2),new Point(2,4),new Point(2,2),new Point(3,3),new Point(4,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(1,1),new Point(1,3),new Point(2,2),new Point(3,1),new Point(3,3)}));
		//4 Corners                 
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,0),new Point(0,4),new Point(4,0),new Point(4,4)}));
		//Crosses                         
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,2),new Point(2,0),new Point(2,2),new Point(2,4),new Point(4,2)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(3,2),new Point(1,2),new Point(2,2),new Point(2,1),new Point(2,3)}));
		//Diagonal Angles                  
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,0),new Point(1,1),new Point(2,2),new Point(1,3),new Point(0,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,0),new Point(1,1),new Point(2,2),new Point(3,1),new Point(4,0)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(4,0),new Point(3,1),new Point(2,2),new Point(3,3),new Point(4,4)}));
		combos.Add(new WinningCombo(new List<Point>(){new Point(0,4),new Point(1,3),new Point(2,2),new Point(3,3),new Point(4,4)}));
	}


    public static bool CheckForBingo(Card card, List<BingoNumber> calledNumbers)
    {
        for(int i=0; i<32; i++){
            //if at least one winning combo is fulfilled, then bingo is fulfilled
            if(combos[i].checkWinningCombo(card, calledNumbers))
                return true;
            }
        //if none of the combos come clean, then no bingo.
        return false;
    }

    public static WinningCombo getWinningCombo(int index){
        //Debug.Log(index);
        return combos[index];
    }

}
