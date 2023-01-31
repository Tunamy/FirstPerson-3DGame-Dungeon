using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public CharacterController characterController;

    public float speed = 5;
    public float gravity = -9.8f;
    public float jumpForce = 300;
    
    private Vector3 velocity;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundLayer;
    public bool isGrounded;

    public GameObject granadaPrefab;
    public float fuerzaGranada = 550f;
    public Transform granadaSpawn;
    public int fuerzabombeo = 50;

    

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime); //*spreenspeed si quiero meterle sprin

        //gravedad

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //salto

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.granadas > 0)
        {
            LanzarGranada();
        }

    }

    private void LanzarGranada()
    {
        

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            
            Vector3 direction = hit.point - granadaSpawn.position; //me da el vector de el spawn point hasta el centro de la camara
            direction.Normalize();

            GameObject nuevaGranada = Instantiate(granadaPrefab, granadaSpawn.position, granadaSpawn.rotation);
            nuevaGranada.GetComponent<Rigidbody>().AddForce(direction * fuerzaGranada + new Vector3(0, fuerzabombeo, 0));

            GameManager.instance.granadas--;
            
        }
    }

   

}
