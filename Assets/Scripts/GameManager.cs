using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public int puntosNivelCompletado;
    public int puntos;

    public float vida;
    public float vidaMax = 100;
    public Image Barradevida;

    public int gunAmmo = 30;
    private int gunammoAnterio;
    public int granadas = 3;
    public GameObject[] granadasUI;

    public GameObject panelPause;
    bool isPaused = false;

    public GameObject baston;
    public GameObject espada;
    public GameObject bastoninfo;
    public GameObject espadainfo;

    public TextMeshProUGUI textAmmo;
    public TextMeshProUGUI infoText;

    public GameObject dmgScreen;
    public CapsuleCollider colliderPlayer;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        panelPause.SetActive(false);

        vida = vidaMax;
        Barradevida.fillAmount = vida;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseGame();

        }

        if(vida > 100)
            vida= 100;

        if(gunAmmo > 30)
            gunAmmo = 30;
        

        if (granadas > 3)
            granadas = 3;


        if(gunAmmo != gunammoAnterio)
        {
            gunammoAnterio = gunAmmo;
            textAmmo.text = GameManager.instance.gunAmmo.ToString();
        }

        Barradevida.fillAmount = vida / vidaMax;


        CambioArmaUI();
        BombasUI();

    }

    private void BombasUI()
    {
        if (granadas == 0)
        {
            granadasUI[1].SetActive(false);
            granadasUI[0].SetActive(false);
            granadasUI[2].SetActive(false);
        }
        else if (granadas == 1)
        {

            granadasUI[1].SetActive(false);
            granadasUI[0].SetActive(false);
            granadasUI[2].SetActive(true);
        }
        else if (granadas == 2)
        {

            granadasUI[2].SetActive(true);
            granadasUI[1].SetActive(true);
            granadasUI[0].SetActive(false);
        }
        else if(granadas == 3)
        {
            granadasUI[2].SetActive(true);
            granadasUI[1].SetActive(true);
            granadasUI[0].SetActive(true);
        }
    }

    private void CambioArmaUI()
    {
        if (baston.activeInHierarchy == true)
        {
            bastoninfo.SetActive(true);
        }
        else
        {
            bastoninfo.SetActive(false);
        }

        if(espada.activeInHierarchy == true)
        {
            espadainfo.SetActive(true);
        }
        else
        {
            espadainfo.SetActive(false);
        }
    }

    public void PerderVida(int da�o)
    {

        

        vida -= da�o;
        Barradevida.fillAmount = vida / vidaMax;

        StartCoroutine("Invulnerable");
        

        if(vida <= 0)
        {
            //reiniciar nivel
        }

    }

    private IEnumerator Invulnerable()
    {
        dmgScreen.SetActive(true);
        colliderPlayer.enabled = false;

        yield return new WaitForSeconds(0.7f);

        dmgScreen.SetActive(false);
        colliderPlayer.enabled = true;
    }

    private void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            panelPause.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }

    }

    public void Informacion(string texto)
    {
        infoText.text = texto;
    }
}
