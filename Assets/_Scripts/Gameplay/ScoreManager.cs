using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI DiamondCountText;

    public Transform Player;

    private int CurrentScore;
    private int HighScore;
    public int DiamondCount;

    public bool ScoreIncreasing;

	// Use this for initialization
	void Start ()
    {
        ScoreIncreasing = true;
        if(PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
       if(ScoreIncreasing)
        {
            CurrentScore = (int)Player.transform.position.x;
        }

        if(CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }

        ScoreText.text = CurrentScore.ToString("0" + "m");
        HighScoreText.text = HighScore.ToString("BEST:"+"0");
        DiamondCountText.text = DiamondCount.ToString("0");
	}
}
