using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject particleShoot;
    public int dañoPorbala = 1;
    


    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        GameObject newParticula = Instantiate(particleShoot, gameObject.transform.position, Quaternion.identity);
        Destroy(newParticula, 2);
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("DmgAsset"))
        {
            Debug.Log("dsfd");
            collision.gameObject.GetComponent<DestroyAsset>().QuitarVidas(dañoPorbala);
            
        }

        if (collision.gameObject.CompareTag("Puerta")) 
        {

            collision.gameObject.GetComponent<DestroyAsset>().QuitarVidas(dañoPorbala);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            GameManager.instance.puntos++;
            collision.gameObject.GetComponent<DestroyAsset>().QuitarVidas(dañoPorbala);
        }
    }
}
