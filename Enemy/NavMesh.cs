using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{ 
    public Transform player;
    public bool isAttack;

    public void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.name== "Player")
        {
            isAttack = true;
        }
    }

    public void Update()
    {
        if(isAttack)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = player.position;
        }
    }
}
