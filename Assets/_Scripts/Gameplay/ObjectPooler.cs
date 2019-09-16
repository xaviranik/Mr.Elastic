using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject PooledObject;
    public int PooledAmount;

    List<GameObject> PooledObjects;
	// Use this for initialization
	void Start ()
    {
        PooledObjects = new List<GameObject>();

        for(int i=0; i< PooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(PooledObject);
            obj.SetActive(false);
            PooledObjects.Add(obj);
        }
	}
	
	public GameObject GetPooledObject()
    {
        for(int i=0; i<PooledObjects.Count; i++)
        {
            if(!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(PooledObject);
        obj.SetActive(false);
        PooledObjects.Add(obj);
        return obj;
    }
}
