using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IASImple : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform destinoActual;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        agent.destination = destinoActual.transform.position;

    }


}
