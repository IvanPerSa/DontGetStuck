using UnityEngine;

public class LevantarObjeto : MonoBehaviour
{
    public Transform puntoSujecion; // Empty GameObject en el personaje indicando la posición del objeto sostenido
    private bool enZona = false;
    private bool levantado = false;
    private Transform personaje;
    private Rigidbody2D rb;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E))
        {
            if (!levantado)
            {
                Levantar();
            }
            else
            {
                Soltar();
            }
        }

        if (levantado)
        {
            SeguirPersonaje();
        }
    }

    void Levantar()
    {
        levantado = true;
        rb.isKinematic = true;  // Desactiva la gravedad para que no caiga
        col.enabled = true;  // Mantiene la colisión activa
        transform.parent = personaje;  // Lo ancla al personaje
        transform.position = puntoSujecion.position;  // Lo coloca en la posición correcta
    }

    void Soltar()
    {
        levantado = false;
        rb.isKinematic = false;  // Reactiva la gravedad
        col.enabled = true;  // Asegura que siga colisionando
        transform.parent = null;  // Lo separa del personaje
    }

    void SeguirPersonaje()
    {
        transform.position = puntoSujecion.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal"))
        {
            enZona = true;
            personaje = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal"))
        {
            enZona = false;
        }
    }
}
