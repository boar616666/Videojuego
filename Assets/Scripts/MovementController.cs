using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Velocidad y salto del personaje
    public float movementSpeed = 3.0f;
    public float jumpForce = 3.0f;

    // Representa la ubicación del Player o Enemy
    Vector2 movement = new Vector2();

    // Referencias a componentes
    Rigidbody2D rb2D;
    Animator animator;

    // Variable del Animator
    string animationState = "AnimationState"; // Nombre del parámetro entero en Animator

    // Enumeración de los estados de animación
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }

    // Start se llama al iniciar
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        this.UpdateState(); // Invoca al método para actualizar el estado de animación
    }

    // FixedUpdate se usa para manejar física
    private void FixedUpdate()
    {
        MoveCharacter(); // Método definido para ingresar la dirección
    }

    // Método que captura el movimiento y aplica la velocidad
    private void MoveCharacter()
    {
        // Captura los datos de entrada del usuario
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Conserva el rango de velocidad
        movement.Normalize();

        // Aplica la velocidad al Rigidbody2D
        rb2D.velocity = movement * movementSpeed;
    }

    // Método que define la animación según el movimiento
    private void UpdateState()
    {
        if (movement.x > 0) // ESTE
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (movement.x < 0) // OESTE
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else if (movement.y > 0) // NORTE
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (movement.y < 0) // SUR
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else // IDLE
        {
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
        }
    }
}
