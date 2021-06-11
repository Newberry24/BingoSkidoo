using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreen:MonoBehaviour
{
    private int difficultySelection = 0;
    private string[] difficultyLevels = new string[] { "Easy", "Normal", "Hard" };
    private int cardSelection = 0;
    private string[] numberText = new string[] {"1", "2", "3", "4", "5", "6"};
    //GUI Rectangle variables
    private float dx, dy, dw, dh, cx, cy, cw, ch;

    public Text moneyText, dText, cText, neMoneyText;
    public Canvas canvas;
    public Camera cam;

    void Start()
    {
        neMoneyText.gameObject.SetActive(false);
        moneyText.text = string.Format("Money: {0:c}", MoneyHolder.Amount);
    }

    void Update()
    {
        Vector3[] dCorners = new Vector3[4];
        Vector3[] cCorners = new Vector3[4];
        Vector3[] mCorners = new Vector3[4];
        dText.GetComponent<RectTransform>().GetWorldCorners(dCorners);
        cText.GetComponent<RectTransform>().GetWorldCorners(cCorners);
        moneyText.GetComponent<RectTransform>().GetWorldCorners(mCorners);
        //Debug.Log(dCorners[0]+", " + dCorners[1] + ", " + dCorners[2] + ", " + dCorners[3]);
        Vector3 dll = cam.WorldToScreenPoint(dCorners[0]);
        Vector3 dur = cam.WorldToScreenPoint(dCorners[2]);
        Vector3 cll = cam.WorldToScreenPoint(cCorners[0]);
        Vector3 cur = cam.WorldToScreenPoint(cCorners[2]);
       // Vector3 mll = cam.WorldToScreenPoint(mCorners[0]);
        Vector3 mur = cam.WorldToScreenPoint(mCorners[2]);
        dx = dll.x;
        dy = cam.pixelHeight - dll.y;
        dw = dur.x - dll.x;
        dh = dll.y - mur.y;
        cx = cll.x;
        cy = cam.pixelHeight - cll.y;
        cw = cur.x - cll.x;
        ch = cll.y - mur.y;
    }

    void OnGUI()
    {
        difficultySelection = GUI.SelectionGrid(
            new Rect(dx, dy, dw, dh), difficultySelection, 
			difficultyLevels, 1);
        cardSelection = GUI.SelectionGrid(
            new Rect(cx, cy, cw, ch), cardSelection, 
			numberText, 2);
    }

    public void StartGame(){
        if ((decimal)((cardSelection + 1) * .1) <= MoneyHolder.Amount)
        {
            switch (difficultySelection)
            {
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
            Application.LoadLevel("Game" + (cardSelection + 1) + "Cards");
        }
        // Only gets executed when there isn't enough money.
        else
        {
            StopCoroutine(ToggleNoMoneyDisplay());
            StartCoroutine(ToggleNoMoneyDisplay());
        }
    }

    //Toggle the message that there isn't enough money
    private IEnumerator ToggleNoMoneyDisplay()
    {
        for(int i = 0; i < 5; i++)
        {
            neMoneyText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            neMoneyText.gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
        }
    }

    public void LoadInstructions(){
        Application.LoadLevel("How to Play 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

