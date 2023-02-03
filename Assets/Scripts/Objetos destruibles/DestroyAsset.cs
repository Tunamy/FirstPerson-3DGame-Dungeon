using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsset : MonoBehaviour
{
    public GameObject particulas;
    public int vidas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitarVidas(int dmg)
    {
        Debug.Log(dmg);
        
            vidas -= dmg;

        if( vidas <= 0 && gameObject.tag == "Enemy")
        {
            GameManager.instance.puntos++;
        }
        if( vidas <= 0)
        {
            GameObject newParticulas = Instantiate(particulas, transform.position, transform.rotation);
            Destroy(newParticulas, 2.1f);
            Destroy(gameObject, 0.2f);
        }
    }
}
