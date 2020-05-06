using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        int gameplayCount = PlayerPrefs.GetInt("GameplayCount");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
