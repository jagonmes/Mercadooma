using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    private Vector3 destination;
   
    private GameObject personaje;

    private float alcance = 25.0f;


    void Start()
    {
        personaje = GameObject.Find("Jugador");
        destination = getRandomDestiny();
        navMeshAgent.destination = destination;  
    }

    
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, personaje.transform.position);
        float distance = Vector3.Distance(transform.position, destination);

        if (distanceToPlayer < 50)
        {
            navMeshAgent.destination = personaje.transform.position;
        }
        else
        {
            navMeshAgent.destination = destination;
        }
        if(distance<2)
        {
            destination = getRandomDestiny();
            navMeshAgent.destination = destination;
        }
    }

    Vector3 getRandomDestiny() {
        Vector3 randomDirection = Random.insideUnitSphere * alcance;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, alcance, 1);
        return hit.position;
    }
}
