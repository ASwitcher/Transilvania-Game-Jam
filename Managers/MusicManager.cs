using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;

    

    public static MusicManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("MusicManager");
                go.AddComponent<MusicManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

}
