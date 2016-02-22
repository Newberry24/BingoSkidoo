using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreen:MonoBehaviour
{
    private int difficultySelection = 0;
    private string[] difficultyLevels = new string[] { "Easy", "Normal", "Hard" };
    private int cardSelection = 0;
    private string[] numberText = new string[] {"1", "2", "3", "4", "5", "6"};

    public Text moneyText;
    public Canvas canvas;
    void Start()
    {
        moneyText.text = "Money: " + MoneyHolder.Amount;
    }
    
    void OnGUI()
    {
        difficultySelection = GUI.SelectionGrid(
            new Rect(180 ,200, 100 , 150), difficultySelection, 
			difficultyLevels, 1);
        cardSelection = GUI.SelectionGrid(
            new Rect(650, 200, 150, 150), cardSelection, 
			numberText, 2);
    }

    public void StartGame(){
        switch(difficultySelection){
            case 0:
		    Game.setLevel(Difficulty.Easy);
            break;
            case 1:
		    Game.setLevel(Difficulty.Normal);
            break;
            case 2:
		    Game.setLevel(Difficulty.Hard);
            break;
        }
        Application.LoadLevel("Game"+(cardSelection + 1) + "Cards");
    }

    public void LoadInstructions(){
        Application.LoadLevel("Instructions Menu");
    }
}

