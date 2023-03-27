using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //Variables controlables por editor
    [SerializeField] private float MoveSmoothTime;
    [SerializeField] private float JumpMoveSmoothTime;
    [SerializeField] private float GravityStrength;
    [SerializeField] private float JumpStrength;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;

    private float LastSpeed = 0f;


    //Controlador
    private CharacterController Controller;

    //Para cálculos
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    private Vector3 CurrentForceVelocity;

    public void PhysicalHit(Vector3 fuerza) {
        CurrentMoveVelocity += fuerza;
    }

    void Start()
    {
        //Asignamos el controlador
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Lanzamos un rayo para comprobar si estamos en el suelo
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        //nuestro pesonaje ahora mismo mide 1, por eso el 1.1f puede que se cambie más adelante
        bool OnGround = Physics.Raycast(groundCheckRay, 1.1f);

        //Leemos y normalizamos la entrada 
        Vector3 PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        if (PlayerInput.magnitude > 1f)
            PlayerInput.Normalize();

        //Recalculamos la dirección del movimiento
        Vector3 MoveVector = transform.TransformDirection(PlayerInput);

        //Comprobamos si corremos o no, para elegir la velocidad
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;

        //Comprobamos si estamos en el aire, si lo estamos, no podemos cambiar nuestra aceleración, y la capacidad para cambiar de dirección se reduce
        if (!OnGround)
        {
            CurrentSpeed = LastSpeed;
            //Si no estamos en el suelo, se resta la fuerza de la gravedad a nuestra fuerza actual en el eje y
            CurrentForceVelocity.y -= GravityStrength * Time.deltaTime;

            //Se calcula la velocidad del movimiento (con más dificultad para cambiar de dirección)
            CurrentMoveVelocity = Vector3.SmoothDamp(CurrentMoveVelocity, MoveVector * CurrentSpeed, ref MoveDampVelocity, JumpMoveSmoothTime);
        }
        else {

            //Se calcula la velocidad del movimiento
            CurrentMoveVelocity = Vector3.SmoothDamp(CurrentMoveVelocity, MoveVector * CurrentSpeed, ref MoveDampVelocity, MoveSmoothTime);

            //Se asigna -2 a la velocidad horizontal para que se mantenga pegado al suelo
            CurrentForceVelocity.y = -2f;

            //Se comprueba si se pulsa espacio, en cuyo caso se asigna la fuerza del salto a la componente y del movimiento
            if (Input.GetKey(KeyCode.Space))
            {
                CurrentForceVelocity.y = JumpStrength;
            }

        }

        //Se guarda la ultima velocidad conocida;
        LastSpeed = CurrentSpeed;

        //Se mueve al personaje
        Controller.Move(CurrentMoveVelocity * Time.deltaTime);
        Controller.Move(CurrentForceVelocity * Time.deltaTime);

    }
}
