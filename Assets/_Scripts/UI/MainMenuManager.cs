using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour {

    public TextMeshProUGUI HighScoreText;
    private int HighScore;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
        }

        HighScoreText.text = HighScore.ToString("0" + "m");
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("LoadScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
