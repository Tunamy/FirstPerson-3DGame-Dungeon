using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformacionTriger : MonoBehaviour
{
    public string mensaje;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Informacion(mensaje);
        }
    }
}
