using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinScreen : MonoBehaviour
{
    //used for the amount of stars
    int winCount;

    int level;
    float timer;

    //stars
    public Image redStar;
    public Image orangeStar;
    public Image yellowStar;

    //text
    public Text redText;
    public Text orangeText;
    public Text yellowText;

    private void Start()
    {
        level = PlayerPrefs.GetInt("Level");
        timer = PlayerPrefs.GetFloat("TimeTaken");
        Debug.Log(timer);

        getTimeValue();
    }

    //what to do with the continue button
    public void continueButton() {
        Application.LoadLevel("LevelSelect");
    }

    public void getTimeValue() {
        switch (level){

            //level one
            case 1:
                if (timer >= 20 && timer < 30) {
                    winCount = 2;
                }
                else if (timer >= 10 && timer < 20)
                {
                    winCount = 3;
                }
                else {
                    winCount = 1;
                }
                //what time is required for each star
                redText.text = "45.00";
                orangeText.text = "30.00";
                yellowText.text = "20.00";
                //display the sprites
                winDisplay();
                break;

            //level two
            case 2:
                if (timer >= 10 && timer < 20)
                {
                    winCount = 2;
                }
                else if (timer >= 5 && timer < 10)
                {
                    winCount = 3;
                }
                else
                {
                    winCount = 1;
                }
                //what time is required for each star
                redText.text = "45.00";
                orangeText.text = "20.00";
                yellowText.text = "10.00";
                //display the sprites
                winDisplay();
                break;

            default:
                break;
        }

    }

    public void winDisplay() {
        //1 star
        if (winCount == 1) {
            orangeStar.color = Color.black;
            yellowStar.color = Color.black;
        }
        //2 stars
        if (winCount == 2)
        {
            yellowStar.color = Color.black;
        }
        if (winCount == 3) {
        }
    }

}
