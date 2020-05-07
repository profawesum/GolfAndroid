using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    float timer;
    public GameObject timerGO;
    public Text timerText;

    public int level;

    bool timerToGo = true;

    public void restart() {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void home() {
        Application.LoadLevel("LevelSelect");
    }

    private void Start()
    {
        timerText = timerGO.GetComponent<Text>();
        int gameplayCount = PlayerPrefs.GetInt("GameplayCount");

        if (gameplayCount >= 5) {
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

    private void Update()
    {
        if (timerToGo)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F2");
        }
    }

    IEnumerator WaitforEnd()
    {
        timerToGo = false;
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetFloat("TimeTaken", timer);
        PlayerPrefs.SetInt("LevelUnlocked", level);
        //yield on a new YieldInstruction that waits for 1.5 seconds.
        yield return new WaitForSeconds(1.5f);
        //load the level complete scene
        Application.LoadLevel("LevelWin");

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
