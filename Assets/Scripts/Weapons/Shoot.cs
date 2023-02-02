using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawmPoint;
    public GameObject bullet;

    public float shotForce = 700f;
    public float shotRate = 0.3f; //tiempo entre disparo
    private float shotRateTime = 0;

    public Animator bastonAnim;

    public TextMeshProUGUI textAmmo;

    private void Start()
    {
        textAmmo.text = GameManager.instance.gunAmmo.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //boton derecho
        {
            
            if (Time.time > shotRateTime && GameManager.instance.gunAmmo > 0) 
            {

                 //resta una bala

                

                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    bastonAnim.SetTrigger("Shoot");

                    Vector3 direction = hit.point - spawmPoint.position; //me da el vector de el spawn point hasta el centro de la camara
                    direction.Normalize();


                    GameObject newBullet = Instantiate(bullet, spawmPoint.position, spawmPoint.rotation);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * shotForce);//añade una fuerza recta por la fuerza

                    shotRateTime = Time.time + shotRate;
                    Destroy(newBullet, 3);

                    GameManager.instance.gunAmmo--;

                    textAmmo.text = GameManager.instance.gunAmmo.ToString();
                }
            }
        }
    }
}
