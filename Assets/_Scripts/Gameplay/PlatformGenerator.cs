using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject Platform;
    public Transform GenerationPoint;
    private float DistanceBetween;

    private float[] PlatformWitdhs;
    public float DistanceBetweenMin;
    public float DistanceBetweenMax;

    private float MinHeight;
    public Transform MaxHeightPoint;
    private float MaxHeight;
    public float MaxHeightChange;
    private float HeightChange;

    public ObjectPooler[] ObjPools;

    private int PlatformSelector;
    
    //coin variables
    private CoinGenerator CoinGnrtr;
    public float RandomCoinThreshold;

	// Use this for initialization
	void Start ()
    {
        PlatformWitdhs = new float[ObjPools.Length];

        for(int i=0; i<ObjPools.Length; i++)
        {
            PlatformWitdhs[i] = ObjPools[i].PooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        MinHeight = transform.position.y;
        MaxHeight = MaxHeightPoint.position.y;

        CoinGnrtr = FindObjectOfType<CoinGenerator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < GenerationPoint.position.x)
        {

            DistanceBetween = Random.Range(DistanceBetweenMin, DistanceBetweenMax);

            PlatformSelector = Random.Range(0, ObjPools.Length);

            HeightChange = transform.position.y + Random.Range(MaxHeightChange, -MaxHeightChange);

            if(HeightChange > MaxHeightChange)
            {
                HeightChange = MaxHeight;
            }
            else if(HeightChange < MinHeight)
            {
                HeightChange = MinHeight;
            }

            transform.position = new Vector3(transform.position.x + (PlatformWitdhs[PlatformSelector] / 2) + DistanceBetween, HeightChange, transform.position.z);

            //Instantiate(Platform, transform.position, transform.rotation);

            GameObject NewPlatform = ObjPools[PlatformSelector].GetPooledObject();

            NewPlatform.transform.position = transform.position;
            NewPlatform.transform.rotation = transform.rotation;
            NewPlatform.SetActive(true);

            if(Random.Range(0f, 100f) < RandomCoinThreshold)
            {
                CoinGnrtr.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z));
            }
            

            transform.position = new Vector3(transform.position.x + (PlatformWitdhs[PlatformSelector] / 2), transform.position.y, transform.position.z);

        }
	}
}
