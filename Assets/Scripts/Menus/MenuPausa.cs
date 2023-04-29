using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

    public static bool juegoPausado = false;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
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
        botonPausa.SetActive(true);
        menuPausa.SetActive(true);
    }
   
    public void Reanudar()
     {
        Cursor.visible = false;
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(false);
     }
    public void Reiniciar()
     {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
    public void Cerrar()
    {
        Debug.Log("Cerrando Juego...");
        Application.Quit();
    }
    
}





