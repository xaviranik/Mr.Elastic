using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public void RetryGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
