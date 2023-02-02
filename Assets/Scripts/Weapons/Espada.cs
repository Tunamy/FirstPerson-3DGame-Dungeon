using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public Animator animEspada;

    public float shotRate = 0.5f; //tiempo entre disparo
    private float shotRateTime = 0;
    public int dañoPorGolpe = 3;

    public GameObject particulas;
    public SphereCollider collaider;
    public Transform puntaEspada;

    // Start is called before the first frame update
    void Start()
    {
        collaider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shotRateTime)
            {
                animEspada.SetTrigger("Mele");

                shotRateTime = Time.time + shotRate;
            }
        }
    }

    public void OnCollisionEnter(Collision collision) 
    
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        Debug.Log("colisiona");
        GameObject newParticula = Instantiate(particulas, puntaEspada.position, Quaternion.identity);
        Destroy(newParticula, 2);

        if (collision.gameObject.CompareTag("DmgAsset"))
        {
            Debug.Log("dsfd");
            collision.gameObject.GetComponent<DestroyAsset>().QuitarVidas(dañoPorGolpe);

        }

        // poner romper puerta
        if (collision.gameObject.CompareTag("Puerta"))
        {

            collision.gameObject.GetComponent<DestroyAsset>().QuitarVidas(dañoPorGolpe);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            GameManager.instance.puntos++;
            collision.gameObject.GetComponent<DestroyAsset>().QuitarVidas(dañoPorGolpe);
        }
    }

   

    public void Atacando()
    {
        collaider.enabled = true;
    }

    public void NoAtacando()
    {
        collaider.enabled = false;
    }
}
  

