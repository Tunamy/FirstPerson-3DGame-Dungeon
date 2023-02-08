using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoConVIda : MonoBehaviour
{
    public GameObject particulas;
    public int da�o = 10;
    public float vidas;
    public float vidaMax = 10;
    public Image Barradevida;
    public Animator animacionara�a;

    // Start is called before the first frame update
    void Start()
    {
        vidas = vidaMax;
        Barradevida.fillAmount = vidas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitarVidas(int dmg)
    {
        Debug.Log(dmg);

        vidas -= dmg;

        Barradevida.fillAmount = vidas / vidaMax;

        Debug.Log(Barradevida.fillAmount);

        if (vidas <= 0 && gameObject.tag == "Enemy")
        {
            GameManager.instance.puntos++;
            GameObject newParticulas = Instantiate(particulas, transform.position + new Vector3(0,1,0), transform.rotation);
            Destroy(newParticulas, 2.1f);
            Destroy(gameObject);
        }

        if (vidas <= 0 && gameObject.tag == "Ara�a" && gameObject.GetComponent<Ara�a>())
        {
            GameManager.instance.puntos++;
            animacionara�a.SetTrigger("Dead");
            Invoke("InstanciarParticulas", 1.8f);
            gameObject.GetComponent<Ara�a>().agent.speed = 0;
            
            Destroy(gameObject, 2);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PerderVida(da�o);
        }
    }

    public void InstanciarParticulas()
    {
        GameObject newParticulas = Instantiate(particulas, transform.position + new Vector3(0, 1, 0), transform.rotation);
        Destroy(newParticulas, 2.1f);
    }
}
