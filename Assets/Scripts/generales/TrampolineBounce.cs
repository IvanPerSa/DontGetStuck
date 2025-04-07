using UnityEngine;

public class TrampolineBounce : MonoBehaviour
{
    public float bounceForce = 10f; // Fuerza con la que lanzar� al personaje
    public Animator animator; // Referencia al Animator del trampol�n

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "PersonajePrincipal"
        if (collision.gameObject.CompareTag("PersonajePrincipal"))
        {
            // Llamar a la animaci�n de empuje (Push) utilizando el trigger
            animator.SetTrigger("Push");

            // Obtener el Rigidbody2D del PersonajePrincipal
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                // Aplicar una fuerza hacia arriba
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
            }
        }
    }
}
