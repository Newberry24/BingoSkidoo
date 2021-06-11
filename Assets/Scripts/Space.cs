using UnityEngine;
using UnityEngine.UI;

public class Space : MonoBehaviour {
    private int number;

    public int Number
    {
        get { return number; }
        set { number = value; }
    }
    public bool freeSpace;
    public Text display;
    public GameObject daub;

    public int GenerateNumber(int column)
    {
        //Randomly Generate a number if not a free space
        if(!freeSpace){
            //The number picked depends on the column.
            switch(column){
                case 0:
					number = Random.Range(1, 16);
                break;
                case 1:
					Number = Random.Range(16, 31);
                break;
                case 2:
					Number = Random.Range(31, 46);
                break;
                case 3:
					Number = Random.Range(46, 61);
                break;
                case 4:
					Number = Random.Range(61, 76);
                break;
                default:
                    Debug.Log("Error: Column Char Not Recognized");
                break;
            }
            display.text = number.ToString();
            return number;
        }
        return 0;
    }

    public void ToggleDaub()
    {
        daub.SetActive(!daub.activeSelf);
    }

}
