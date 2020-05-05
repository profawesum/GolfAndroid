using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KillFloor")
        {
            //restart the level
            Application.LoadLevel(Application.loadedLevel);
        }
        if (other.tag == "LevelEnd") {
            //load into level select screen
            Application.LoadLevel("LevelSelect");
        }
    }
}
