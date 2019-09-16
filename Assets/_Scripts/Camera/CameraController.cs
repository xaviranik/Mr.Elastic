using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerMovement Player;
    private Vector3 LastPlayerPosition;
    private float DistanceToMove;

	// Use this for initialization
	void Start ()
    {
        Player = FindObjectOfType<PlayerMovement>();
        LastPlayerPosition = Player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DistanceToMove = Player.transform.position.x - LastPlayerPosition.x;
        transform.position = new Vector3 (transform.position.x + DistanceToMove,transform.position.y,transform.position.z);

        LastPlayerPosition = Player.transform.position;
	}
}
