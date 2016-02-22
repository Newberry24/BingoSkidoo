using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {
    public void LoadPrevious()
    {
        Application.LoadLevel(Application.loadedLevel - 1);
    }
    public void LoadNext()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void BackToMenu()
    {
        Application.LoadLevel("Instructions Menu");
    }

}
