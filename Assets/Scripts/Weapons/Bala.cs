using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject particleShoot;
    private void OnCollisionEnter(Collision collision)
    {
        
        GameObject newParticula = Instantiate(particleShoot, gameObject.transform.position, Quaternion.identity);
        Destroy(newParticula, 2);
        Destroy(gameObject);
    }
}
