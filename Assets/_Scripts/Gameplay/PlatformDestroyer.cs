using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    private GameObject PlatformDestructionPoint;
	// Use this for initialization
	void Start ()
    {
        PlatformDestructionPoint = GameObject.Find("PlatformDestroyPoint");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x < PlatformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);


        }
	}
}
