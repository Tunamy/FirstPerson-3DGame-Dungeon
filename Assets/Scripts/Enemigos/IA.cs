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
    public GameObject alerta;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destinoActual.transform.position; // al comienzo va a un destino
        destinoActual = destino;
        alerta.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, destino.transform.position); // si la distancia en menor que 3 va a por ese

        if (distancia < 7)
        {
            destinoActual = destino;
            alerta.SetActive(false);
            agent.stoppingDistance = 0;
        }
        float distancia1 = Vector3.Distance(transform.position, destino2.transform.position);
        if (distancia1 < 7)
        {
            alerta.SetActive(true);
            destinoActual = destino2;
            agent.speed = 3.5f;
            agent.stoppingDistance = 1.5f;
        }

        agent.destination = destinoActual.transform.position;

    }
}
