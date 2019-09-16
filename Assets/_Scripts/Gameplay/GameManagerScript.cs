using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public Transform PlatformGenerator;
    public Vector3 PlatformStartPoint;

    public PlayerMovement Player;
    public Vector3 PlayerStartPoint;

    private PlatformDestroyer[] PlatFormList;

    private ScoreManager ScoreMngr;
    public DeathMenu DeathScreen;

    private void Start()
    {
        ScoreMngr = FindObjectOfType<ScoreManager>();
    }


    public void RestartGame()
    {
        ScoreMngr.ScoreIncreasing = false;
        DeathScreen.gameObject.SetActive(true);
        Player.gameObject.SetActive(false);
        
    }
    
    /*public IEnumerator RestartGameCo()
    {
        ScoreMngr.ScoreIncreasing = false;
        yield return new WaitForSeconds(TimeToWait);
        PlatFormList = FindObjectsOfType<PlatformDestroyer>();

        for(int i=0; i<PlatFormList.Length; i++)
        {
            PlatFormList[i].gameObject.SetActive(false);
        }

        Player.transform.position = PlayerStartPoint;
        PlatformGenerator.position = PlatformStartPoint; 

        SceneManager.LoadScene("Level_1");
    } */

}
