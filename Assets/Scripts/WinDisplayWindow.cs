using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinDisplayWindow : MonoBehaviour {
    private WinningCombo displayedCombo;
	public GameObject[] panels;
    void Start()
    {
        StartCoroutine(WindowFlipper());
    }

    IEnumerator WindowFlipper()
    {
        //Infinite Loop
        while(true){
            
            //Flip between winning combos
            for(int i = 0; i < 32; i++){
                yield return new WaitForSeconds(1);
                displayedCombo = WinningCombos.getWinningCombo(i);
                UpdatePanels(); 
            }
        }
    }

    private void UpdatePanels()
    {
        
       for (int row = 0; row < 5; row++) {
            for (int col = 0; col < 5; col++) {
                //Debug.Log("Row = " + row + " Col = " + col);
                if (displayedCombo.CheckPointInSet(new Point( row, col)))
                    panels[row + col*5].GetComponent<Image>().color = Color.black;
                else
                    panels[row + col*5].GetComponent<Image>().color = Color.white;
            }
        }
    }
}
