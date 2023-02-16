using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionArma : MonoBehaviour
{
    private Quaternion startRotation;
    public float swayAmount = 8f; //cantidad de rotacion

    
    void Start()
    {
        startRotation = transform.localRotation; //guardamos la rotacion inicial
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Sway();
    }

    private void Sway()
    {
        //leer valores del Raton

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion yAngle = Quaternion.AngleAxis(mouseY * -4f, Vector3.up);
        Quaternion xAngle = Quaternion.AngleAxis(mouseX * 4f, Vector3.right);

        Quaternion targetRotation = startRotation * xAngle * yAngle;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * swayAmount);
    }
}
