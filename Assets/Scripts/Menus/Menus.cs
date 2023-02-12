using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PulsarPlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PulsarMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PulsarCreditos()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
        Cursor.visible = true;
    }

    public void Salir()
    {
        Application.Quit();
    }
}
