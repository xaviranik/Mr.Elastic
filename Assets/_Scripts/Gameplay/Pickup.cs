using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int DiamondNum;

    private ScoreManager ScoreMngr;
    private AudioSource CoinPickSound;

    public Animator CoinAnim;

    private void Awake()
    {
        ScoreMngr = FindObjectOfType<ScoreManager>();
        DiamondNum = 0;

        CoinPickSound = GameObject.Find("PickupSound").GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreMngr.DiamondCount += DiamondNum + 1;
            //CoinAnim.Play("DiamondFly");

            CoinAnim.SetTrigger("HasCoin");
            
            
            //gameObject.SetActive(false);

            if (CoinPickSound.isPlaying)
            {
                CoinPickSound.Stop();
                CoinPickSound.Play();
            }
            else
            {
                CoinPickSound.Play();
            }
        }
    }
}
