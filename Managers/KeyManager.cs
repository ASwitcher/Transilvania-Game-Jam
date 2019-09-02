using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private static KeyManager _instance;

    public GameObject gate;

	public int KeysCollectedTotal;

	public static KeyManager Instance
    {
        get
        {
             if(_instance == null)
             {
                     GameObject go = new GameObject("KeyManager");
                     go.AddComponent<KeyManager>();
             }

            return _instance;
        }
   }

    public void Start()
    {
        KeysCollectedTotal = 0;
    }


    void Awake()
    {
    _instance = this;
    }

    
    void Update()
    {
        
       if(KeysCollectedTotal >= 1)
        {
            Debug.Log("The gate is unlocked!");
            Destroy(gate);
        }
    }
}