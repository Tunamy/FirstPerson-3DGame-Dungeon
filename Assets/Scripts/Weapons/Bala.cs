using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bala : MonoBehaviour
{
    public GameObject particleShoot;
    public GameObject luz;
    public int dañoPorbala = 1;



    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject newLuz = Instantiate(luz, gameObject.transform.position, Quaternion.identity);
        GameObject newParticula = Instantiate(particleShoot, gameObject.transform.position, Quaternion.identity);
        Destroy(newLuz, 0.7f);
        Destroy(newParticula, 2);
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("DmgAsset"))
        {

            collision.gameObject.GetComponent<DestroyAsset>().QuitarVidas(dañoPorbala);

        }


        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Araña"))
        {


            collision.gameObject.GetComponent<EnemigoConVIda>().QuitarVidas(dañoPorbala);
        }

        if(collision.gameObject.GetComponent<Araña>() != null)
        {
            collision.gameObject.GetComponent<Araña>().destinoActual = GameObject.Find("Player").transform;
            collision.gameObject.GetComponent<Araña>().destino = GameObject.Find("Player").transform;
            collision.gameObject.GetComponent<Araña>().enSpawn = false;
        }
    }

}
