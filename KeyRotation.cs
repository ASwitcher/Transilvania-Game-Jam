using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotation : MonoBehaviour
{
    public float speedRotation;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedRotation * Time.deltaTime*10, 0f, 0f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
