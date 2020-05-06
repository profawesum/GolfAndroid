using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{


    private void Start()
    {
        int gameplayCount = PlayerPrefs.GetInt("GameplayCount");

        if (gameplayCount >= 2) {
            gameplayCount = 0;
            PlayerPrefs.SetInt("GameplayCount", gameplayCount);
            showAd();
        }
    }

    void showAd() {
        const string PlacementID = "video";
        if (Advertisement.IsReady()) {
            Advertisement.Show(PlacementID, new ShowOptions() { resultCallback = adViewResult });
        }
    }

    public void adViewResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log(" Player viewed complete Ad");
                break;
            case ShowResult.Skipped:
                Debug.Log(" Player Skipped Ad "); break;
            case ShowResult.Failed:
                Debug.Log("Problem showing Ad "); break;
        }
    }

    IEnumerator WaitforEnd()
    {
        //yield on a new YieldInstruction that waits for 1.5 seconds.
        yield return new WaitForSeconds(1.5f);
        //load the level select
        Application.LoadLevel("LevelSelect");

    }

    void increaseGameplayCount() {
        int gameplayCount = PlayerPrefs.GetInt("GameplayCount");
        gameplayCount++;
        PlayerPrefs.SetInt("GameplayCount", gameplayCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KillFloor")
        {
            increaseGameplayCount();
            //restart the level
            Application.LoadLevel(Application.loadedLevel);
           
        }
        if (other.tag == "LevelEnd") {
            increaseGameplayCount();
            //load into level select screen
            StartCoroutine(WaitforEnd());
           
        }
    }
}
