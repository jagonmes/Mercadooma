using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform[] destinations;
   
    public GameObject personaje;

    private int i = 0;



    void Start()
    {
        navMeshAgent.destination = destinations[i].transform.position;  
    }

    
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, personaje.transform.position);
        float distance = Vector3.Distance(transform.position, destinations[i].transform.position);

        if (distanceToPlayer < 10)
        {
            navMeshAgent.destination = personaje.transform.position;
        }

        if(distance<2)
        {
            navMeshAgent.destination = destinations[i+1].transform.position;
        }
    }
}
