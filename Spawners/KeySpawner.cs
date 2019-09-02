using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject key;

    public int keysCollected;
    public int maxKeysPerLevel;

    private void Start()
    {
        int keysSpawn = maxKeysPerLevel - keysCollected;
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        for(int i=1;i<=keysSpawn;i++)
             Instantiate(key, allChildren[i].position, Quaternion.identity) ;
    }
    private void Update()
    {
        
    }
}
