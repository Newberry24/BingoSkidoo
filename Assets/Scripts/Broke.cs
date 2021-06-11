using UnityEngine;
using System.Collections;

public class Broke : MonoBehaviour {
    public void StartFresh()
    {
        MoneyHolder.Amount = 10;
        Application.LoadLevel("Title Screen");
    }
}
