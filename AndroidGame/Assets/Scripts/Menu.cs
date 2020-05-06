using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void onButtonClick() {
        Application.LoadLevel("LevelSelect");
    }

    public void onLevelClick(string levelToLoad) {
        Application.LoadLevel(levelToLoad);
    }
}
