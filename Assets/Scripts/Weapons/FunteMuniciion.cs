using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FunteMuniciion : MonoBehaviour
{
    public int municion = 7;
    public int RegenerarVida = 10;
    public int tiempoRegeneracion = 10;
    public GameObject particulas;
    public GameObject luz;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GameManager.instance.granadas++;
            GameManager.instance.gunAmmo += municion;
            GameManager.instance.vida += RegenerarVida;

            StartCoroutine("ResetFuente");
        }
    }

    private IEnumerator ResetFuente()
    {
        particulas.SetActive(false);
        luz.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(tiempoRegeneracion);

        particulas.SetActive(true);
        luz.SetActive(true);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

   
}
