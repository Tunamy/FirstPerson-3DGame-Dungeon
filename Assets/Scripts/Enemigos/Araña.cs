using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Araña : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform destinoActual;
    public Transform destino;
    public Transform destino2;

    public GameObject alerta;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.destination = destinoActual.transform.position; // al comienzo va a un destino
        alerta.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        
            float distancia = Vector3.Distance(transform.position, destino.transform.position); // si la distancia en menor que 3 va a por ese

            if (distancia < 7)
            {
                anim.SetTrigger("Idle");
                destinoActual = destino;
                alerta.SetActive(false);
                agent.stoppingDistance = 0;
            }
            float distancia1 = Vector3.Distance(transform.position, destino2.transform.position);
            if (distancia1 < 7 && distancia1 > 3)
            {
                anim.SetTrigger("Walk");
                alerta.SetActive(true);
                destinoActual = destino2;
                agent.speed = 3.5f;
                agent.stoppingDistance = 2.4f;
            }

            if(distancia1 <= 3)
            {
                anim.SetTrigger("Atack");
            }

            agent.destination = destinoActual.transform.position;

        
    }

}
