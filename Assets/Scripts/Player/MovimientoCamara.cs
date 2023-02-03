using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float ratonSensivilidad = 120f;
    public Transform playerBody;
    public float xRotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //bloquear cursor y que se vea mejor ?�
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        xRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * ratonSensivilidad ;
        float mouseY = Input.GetAxis("Mouse Y") * ratonSensivilidad ;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //bloquea camara en esos rangos;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //hace las rotaciones xD
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
