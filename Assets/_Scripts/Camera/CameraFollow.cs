using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Player;
    public Vector3 Offset;
    public float MaxOffsetY;

    public float SmoothSpeed;

    private void FixedUpdate()
    {
        Vector3 DesiredPos = Player.position + Offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPos, SmoothSpeed * Time.deltaTime);

        if(Player.transform.position.y < MaxOffsetY)
        {
            transform.position = transform.localPosition;
        }
        else
        transform.position = SmoothedPosition;
    }

}
