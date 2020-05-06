using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    IEnumerator ExampleCoroutine()
    {

        Debug.Log("Coroutine");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel("LevelSelect");

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KillFloor")
        {
            //restart the level
            Application.LoadLevel(Application.loadedLevel);
        }
        if (other.tag == "LevelEnd") {
            //load into level select screen
            StartCoroutine(ExampleCoroutine());
           
        }
    }
}
