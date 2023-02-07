using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bala : MonoBehaviour
{
    public GameObject particleShoot;
    public GameObject luz;
    public int da�oPorbala = 1;



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

            collision.gameObject.GetComponent<DestroyAsset>().QuitarVidas(da�oPorbala);

        }


        if (collision.gameObject.CompareTag("Enemy"))
        {


            collision.gameObject.GetComponent<EnemigoConVIda>().QuitarVidas(da�oPorbala);
        }
    }

}
