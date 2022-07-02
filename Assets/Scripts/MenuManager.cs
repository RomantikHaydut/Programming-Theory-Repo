using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public TextMeshProUGUI bestScoreText;

    private TheManager theManager;

    void Start()
    {
        theManager = FindObjectOfType<TheManager>();
        theManager.LoadNameAndScore();
        ShowBestScore();
    }



    public void ShowBestScore()
    {
        bestScoreText.text = "Best Score is : " + TheManager.bestScore + " by : " + TheManager.bestScoreOwner;
    }

    public void ResetBestScore()
    {
        theManager.SaveNameAndScore(" ", 0);
        theManager.LoadNameAndScore();
        ShowBestScore();
    }

    public void NoMusic()
    {
        theManager.SaveMusicIndex(5);
        theManager.PlayMusic(null);
    }
}
