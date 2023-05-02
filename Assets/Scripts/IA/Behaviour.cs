using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Behaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public GameObject destination1;
 
    void Start()
    {
        navMeshAgent.destination = destination1.transform.position; 
    }

    void Update()
    {
        
    }
}
