using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public Animator animEspada;

    public float shotRate = 0.5f; //tiempo entre disparo
    private float shotRateTime = 0;

    public GameObject particulas;
    public BoxCollider collaider;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Caja"))
        //{
        Debug.Log("colisiona");
        GameObject newParticula = Instantiate(particulas, collaider.transform.position, Quaternion.identity);
        Destroy(newParticula, 2);
        //}



    }
}
