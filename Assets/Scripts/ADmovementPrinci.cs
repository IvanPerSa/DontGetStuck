using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float jumpForce = 4f; // Fuerza del salto
    private Rigidbody2D rb; // Referencia al Rigidbody2D

    private int jumpCount = 0; // Contador de saltos

    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer del personaje

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el SpriteRenderer
    }

    private void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // Movimiento horizontal y caída

        // Flip (giro) en el eje X según la dirección
        if (moveInput > 0) // Si el personaje se mueve a la derecha
        {
            spriteRenderer.flipX = false; // No voltear el sprite
        }
        else if (moveInput < 0) // Si el personaje se mueve a la izquierda
        {
            spriteRenderer.flipX = true; // Voltear el sprite en el eje X
        }

        // Comprobar si se presiona la tecla Espacio para saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Si el contador de saltos es 0 o 1, se puede saltar
            if (jumpCount < 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplica la fuerza de salto
                jumpCount++; // Incrementa el contador de saltos
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Restablecer el contador de saltos cuando el personaje toque el suelo
        jumpCount = 0;
    }
}
