using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Game:MonoBehaviour
{
    public List<AudioSource> calls;
    public AudioSource bingo;
    public AudioSource badCall;
    public AudioSource roundOver;
    public int cardCount;
    public Text moneyDisplay;
    public Text callsLeftDisplay;
    public CalledNumberTable callTable;
	
    private static Difficulty level;
    private List<BingoNumber> numbers;
    private int numbersToCall;
    private decimal winnings;
	void Start()
    {
       // Debug.Log("Game Start Initialized");
        WinningCombos.Initialize();
        numbers = new List<BingoNumber>();
        //Construct all bingo numbers
        for(int i = 1; i <= 75; i++)
			numbers.Add(new BingoNumber(i));
        //Deduct money depending on the card count
        MoneyHolder.Deduct((decimal)(cardCount* .1));
        moneyDisplay.text = "Money: $" + MoneyHolder.Amount;
        //set numbers called and winnings depending on the difficulty level.
        switch (level){
            case Difficulty.Easy:
                numbersToCall = 30;
                winnings = (decimal)2.50;
                break;
			case Difficulty.Normal:
                numbersToCall = 25;
                winnings = 5;
                break;
			case Difficulty.Hard:
                numbersToCall = 20;
                winnings = 10;
                break;
        }
        StartCoroutine(CallNumbers());
    }

    

    public static void setLevel(Difficulty picked)
    {
        level = picked;
    }
    public IEnumerator CallNumbers()
    {
        yield return new WaitForSeconds(5);
        for(int i = 0; i < numbersToCall; i++){
            callsLeftDisplay.text = "Calls Left: " + (numbersToCall - i);
            int calledNumber;
            
            //calls a number that has not been called already.
            do{
                calledNumber = Random.Range(0, 75);
            } while(numbers[calledNumber].Called);
            calls[calledNumber].Play();
            numbers[calledNumber].Called = true;
            callTable.EnableText(calledNumber);
            yield return new WaitForSeconds(10);
        }
        for(int i = 20; i >=0; i--){
            callsLeftDisplay.text = "Time Left: " + i;
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(EndRound());
    }

    public void CallBingo(Card card){
        //if bingo has been verified, shout bingo and claim your winnings
        
        if(WinningCombos.CheckForBingo(card, numbers)){
            bingo.Play();
            MoneyHolder.Add(winnings);
        }
        //Otherwise you will be penalized 50 cents for a bad call.
        else{
            badCall.Play();
            MoneyHolder.Deduct((decimal).50);
        }
        //keeps the money floor to 0, even after being penalized.
        if(MoneyHolder.Amount < 0)
            MoneyHolder.Amount = 0;
        moneyDisplay.text = "Money: $" + MoneyHolder.Amount;
        //Removes the card out of play.
        cardCount--;
        Destroy (card.gameObject);
        //Automatically ends the game when there are no cards to play with
        if (cardCount <= 0)
        {
            StopCoroutine(CallNumbers());
            StartCoroutine(EndRound());
        }
    }

    private IEnumerator EndRound()
    {
        yield return new WaitForSeconds(5);
        roundOver.Play();
        yield return new WaitForSeconds(5);
        Application.LoadLevel("Title Screen");
    }
}
