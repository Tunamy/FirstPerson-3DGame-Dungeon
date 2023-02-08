using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaAraña : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().speed = 3f;
            other.gameObject.GetComponent<Player>().jumpForce = 0;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().speed = 5f;
            other.gameObject.GetComponent<Player>().jumpForce = 2;

        }
    }

   
}
