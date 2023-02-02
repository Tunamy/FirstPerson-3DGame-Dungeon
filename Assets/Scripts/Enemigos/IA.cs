using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
     NavMeshAgent agent;
    public Transform destinoActual;
    public Transform destino;
    public Transform destino2;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destinoActual.transform.position; // al comienzo va a un destino
        
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, destino.transform.position); // si la distancia en menor que 3 va a por ese

        if (distancia < 7)
        {
            destinoActual = destino;
        }
        float distancia1 = Vector3.Distance(transform.position, destino2.transform.position);
        if (distancia1 < 7)
        {
            destinoActual = destino2;
        }

        agent.destination = destinoActual.transform.position;

    }
}
