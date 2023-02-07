using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoConVIda : MonoBehaviour
{
    public GameObject particulas;
    public int daño = 10;
    public float vidas;
    public float vidaMax = 10;
    public Image Barradevida;

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
            Destroy(gameObject, 0.2f);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PerderVida(daño);
        }
    }
}
