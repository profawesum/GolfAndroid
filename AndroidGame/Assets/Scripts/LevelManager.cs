using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{

    public GameObject[] levels;

    private void Start()
    {
        //PlayerPrefs.SetInt("LevelUnlocked", 0);
        int levelUnlock = PlayerPrefs.GetInt("LevelUnlocked");
        levels = GameObject.FindGameObjectsWithTag("LevelButtons");
        foreach (GameObject level in levels) {
            for (int i = 1; i < levelUnlock; i++) {
                levels[i].GetComponent<Button>().interactable = true;
            }
            for (int i = levelUnlock + 1; i < levels.Length; i++) {
                levels[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}
