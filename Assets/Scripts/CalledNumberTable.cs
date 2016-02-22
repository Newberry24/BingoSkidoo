using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CalledNumberTable : MonoBehaviour {
    private List<GameObject> numbersText;

    void Start()
    {
        GameObject objectDelegate = GameObject.FindGameObjectWithTag("delegate");
        numbersText = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 1; j <= 15; j++)
            {
                GameObject number;
                number = new GameObject((i * 15 + j).ToString());
                number.SetActive(false);
                number.AddComponent<RectTransform>();
                number.AddComponent<Text>();
                number.GetComponent<RectTransform>().SetParent(
                    gameObject.GetComponent<RectTransform>());
                number.GetComponent<Transform>().localPosition = new Vector3(
                    (-73.5f + 35.5f * i), (45-25*j));
                number.GetComponent<Text>().text = number.name;
                number.GetComponent<Text>().font = objectDelegate.GetComponent<Text>().font;
                number.GetComponent<Text>().fontSize = 30;
                number.GetComponent<Text>().alignment = TextAnchor.LowerCenter;
                
                numbersText.Add(number);        
            }
        }
    }

    public void EnableText(int calledNumber)
    {
        numbersText[calledNumber].SetActive(true);
    }
}
