using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;

    [SerializeField] private GameObject menuAjustes;

    public Image bSonido;
    public Image bMusica;

    public Sprite soundOn;
    public Sprite soundOff;

    public static bool juegoPausado = false;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            
            }
            
        }
    
    }

    public void Pausa()
    {
        Cursor.visible = true;
        juegoPausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }
   
    public void Reanudar()
    {
        Cursor.visible = false;
        juegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        menuAjustes.SetActive(false);
    }

    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AbrirAjustes()
    {
        menuPausa.SetActive(false);
        menuAjustes.SetActive(true);
    }

    public void CerrarAjustes()
    {
        menuPausa.SetActive(true);
        menuAjustes.SetActive(false);
    }

    public void botonSonido() 
    {
        if (bSonido.sprite == soundOn)
        {
            bSonido.sprite = soundOff;
        }
        else 
        {
            bSonido.sprite = soundOn;
        }
    }

    public void botonMusica() 
    {
        if (bMusica.sprite == soundOn)
        {
            bMusica.sprite = soundOff;
        }
        else
        {
            bMusica.sprite = soundOn;
        }
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando Juego...");
        Application.Quit();
    }
    
}





