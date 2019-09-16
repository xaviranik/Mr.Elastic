using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        StartCoroutine(LevelLoad());
    }

    private IEnumerator LevelLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level_1");

    }
}
