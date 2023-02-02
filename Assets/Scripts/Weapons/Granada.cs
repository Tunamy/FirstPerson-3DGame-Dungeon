using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public int dañoGranada = 10;
    public float delay = 1.5f;
    float countDoown;
    public float radius = 4;
    public float fuerzaExplosion = 300f;
    bool exploted = false;

    public GameObject particulas;
    public Animator animator;

    //public AudioSource audioSource;
    //public AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        countDoown = delay;
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countDoown -= Time.deltaTime;
        if (countDoown <= 0 && !exploted)
        {
            exploted = true;
            Exploted();
        }
    }

    private void Exploted()
    {
        GameObject newParticulas = Instantiate(particulas, transform.position, transform.rotation);
        Destroy(newParticulas, 2);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); // lanza una onda con un radio te devuleve los objetos con los que colisiona. 

        foreach (var rangeObject in colliders) //recorer el bucle para ver todos los objetos a los que toca
        {
            
            Rigidbody rb = rangeObject.GetComponent<Rigidbody>(); // si tienen rigid body le aplica la fuerza
            if (rb != null)
            {
                rb.AddExplosionForce(fuerzaExplosion * 10, transform.position, radius);
                
            }
            if (rangeObject.GetComponent<DestroyAsset>() != null)
            {
                rangeObject.GetComponent<DestroyAsset>().QuitarVidas(dañoGranada);
            }

            
        }

        //audioSource.PlayOneShot(explosion);

        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        Destroy(gameObject, delay * 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        animator.enabled = false;
    }
}
