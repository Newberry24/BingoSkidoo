using UnityEngine;
using System.Collections;

public class InstructionsMenu : MonoBehaviour {

    public void Load(string submenu)
    {
        Application.LoadLevel(submenu);
    }
    public void BackToTitleScreen()
    {
        Application.LoadLevel("Title Screen");
    }

}
