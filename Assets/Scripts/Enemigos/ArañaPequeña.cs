using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArañaPequeña : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform destino;
    
    public GameObject alerta;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        
        alerta.SetActive(true);

        anim.SetTrigger("Walk");
        destino = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = destino.transform.position; 

        float distancia = Vector3.Distance(transform.position, destino.transform.position);

        if (distancia <= 3)
        {
            anim.SetTrigger("Atack");
        }

    }
}
