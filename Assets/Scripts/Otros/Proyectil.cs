using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public DisparoController controladorDisparo;
    private bool clavado = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!clavado && collision.collider.CompareTag("ground"))
        {
            clavado = true;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Kinematic; // Se queda clavado
                rb.gravityScale = 0f; // Por si acaso tenía gravedad
            }

            // También puedes congelar la rotación por si acaso
            transform.SetParent(collision.transform); // Se pega al suelo
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (clavado && other.CompareTag("PersonajePrincipal") && Input.GetKeyDown(KeyCode.F))
        {
            if (controladorDisparo != null)
            {
                // Liberar el proyectil y eliminarlo
                controladorDisparo.LiberarProyectil(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
