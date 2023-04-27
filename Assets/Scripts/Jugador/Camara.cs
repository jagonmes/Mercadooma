using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //Referencia a la camara
    [SerializeField] private Transform PlayerCamera;

    //Sensibilidad en ambos ejes
    public Vector2 Sensitivities;

    //Angulos de rotación para jugador y camara
    private Vector2 XYRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }


    void Update()
    {
        if (!MenuPausa.juegoPausado) {
            //Leer X e Y del ratón
            Vector2 MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            //Calcular rotación
            XYRotation.x -= MouseInput.y * Sensitivities.y;
            XYRotation.y += MouseInput.x * Sensitivities.x;

            //Limitar la rotación vertical
            XYRotation.x = Mathf.Clamp(XYRotation.x, -60f, 60f);

            //Giramos al personaje (horizontal)
            transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
            //Giramos la camara (vertical)
            PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);
        }
    }
}
