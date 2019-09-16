using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler Objpooler;

    public float DistanceBetweenCoins;

    public void SpawnCoins(Vector3 StartPosition)
    {
        GameObject Coin1 = Objpooler.GetPooledObject();
        Coin1.transform.position = StartPosition;
        Coin1.SetActive(true);

        /*GameObject Coin2 = Objpooler.GetPooledObject();
        Coin2.transform.position = new Vector3 (StartPosition.x - DistanceBetweenCoins, StartPosition.y, StartPosition.z);
        Coin2.SetActive(true);

        GameObject Coin3 = Objpooler.GetPooledObject();
        Coin3.transform.position = new Vector3(StartPosition.x + DistanceBetweenCoins, StartPosition.y, StartPosition.z);
        Coin3.SetActive(true);*/
    }

}
