using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Araña : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destinoActual;
    public Transform destino;
    public Transform destino2;
    public bool enSpawn;

    public GameObject arañaPequeña;
    public Transform spawnAraña;
    public GameObject alerta;
    Animator anim;

    Transform playerPosition;
    public Transform spawnTelaAraña;
    public int velocidad;
    public GameObject telaAraña;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.destination = destinoActual.transform.position; // al comienzo va a un destino
        alerta.SetActive(false);
        enSpawn = true;

        playerPosition = GameObject.Find("Player").transform;

        InvokeRepeating("InstanciarArañasPequeñas", 0f, 5f);
        InvokeRepeating("DispararTelaraña",0f, 5f);

    }

    // Update is called once per frame
    void Update()
    {

        playerPosition = GameObject.Find("Player").transform;
        float distancia = Vector3.Distance(transform.position, destino.transform.position); // si la distancia en menor que 3 va a por ese

            if (distancia < 7 && enSpawn)
            {
                anim.SetTrigger("Idle");
                destinoActual = destino;
                alerta.SetActive(false);
                agent.stoppingDistance = 0;
            }
            float distancia1 = Vector3.Distance(transform.position, destino2.transform.position);
            if (distancia1 < 10 && distancia1 > 2.7)
            {
                anim.SetTrigger("Walk");
                alerta.SetActive(true);
                destinoActual = destino2;
                
                enSpawn= false;
            }

            if (enSpawn == false)
            {
                anim.SetTrigger("Walk");
                alerta.SetActive(true);
                
                agent.stoppingDistance = 2.5f;
            }

            if(distancia1 <= 2.7)
            {
                anim.SetTrigger("Atack");
            }

            agent.destination = destinoActual.transform.position;
            
        
      
        
    }

    void InstanciarArañasPequeñas()
    {
        if (enSpawn == false)
        {
            Instantiate(arañaPequeña, spawnAraña.position, Quaternion.identity);
        }
    }

    void DispararTelaraña()
    {
        if (enSpawn == false)
        {
            anim.SetTrigger("Disparo");
            agent.speed = 1.2f;
            
            
          
        }
    }

    public void TelaAraña() //la llamamos desde la animacion
    {
        Vector3 playerDirecctio = playerPosition.position - transform.position;
        GameObject nuevaTelaAraña = Instantiate(telaAraña, spawnTelaAraña.position, Quaternion.Euler(-90,45,0));
        nuevaTelaAraña.GetComponent<Rigidbody>().AddForce(playerDirecctio * velocidad);
        agent.speed = 4.5f;
    }
}
