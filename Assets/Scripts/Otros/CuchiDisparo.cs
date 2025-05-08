using UnityEngine;

public class CuchilloDisparo : MonoBehaviour
{
    public float fuerzaLanzamiento = 20f;  // Fuerza de lanzamiento del cuchillo
    public float tiempoInvisible = 0.1f;  // Tiempo que el cuchillo permanece invisible
    private Rigidbody2D rb;  // Rigidbody2D del cuchillo
    private SpriteRenderer spriteRenderer;  // SpriteRenderer para hacer invisible el cuchillo

    private bool disparado = false;  // Controla si el cuchillo está disparado o no

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtén el Rigidbody2D del cuchillo
        spriteRenderer = GetComponent<SpriteRenderer>();  // Obtén el SpriteRenderer del cuchillo
        gameObject.SetActive(false);  // Desactivamos el cuchillo por defecto
    }

    void Update()
    {
        // Detecta cuando el jugador presiona la tecla "E"
        if (Input.GetKeyDown(KeyCode.E) && !disparado)
        {
            DispararCuchillo();
        }
    }

    void DispararCuchillo()
    {
        disparado = true;

        // Activamos el cuchillo antes de lanzarlo
        gameObject.SetActive(true);
        spriteRenderer.enabled = false;  // Hacer el cuchillo invisible

        // Lanzar el cuchillo en la dirección donde está mirando el personaje (dependiendo de la escala local del personaje)
        float direccionX = Mathf.Sign(transform.localScale.x);  // Si el personaje mira a la derecha, devuelve 1. Si a la izquierda, -1.
        rb.linearVelocity = new Vector2(direccionX * fuerzaLanzamiento, 0f);  // Lanzar el cuchillo solo en el eje X

        // Después de un corto tiempo, hacer visible el cuchillo nuevamente
        Invoke(nameof(HacerVisible), tiempoInvisible);
    }

    void HacerVisible()
    {
        spriteRenderer.enabled = true;  // El cuchillo se vuelve visible de nuevo
    }

    // Detecta las colisiones
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (disparado)
        {
            // Verifica si el objeto con el que colisiona tiene un Rigidbody (es un objeto con física)
            if (collision.gameObject.CompareTag("Ragdoll"))
            {
                rb.linearVelocity = Vector2.zero;  // Detener el movimiento del cuchillo
                transform.SetParent(collision.transform);  // Hacer que el cuchillo se enganche al objeto
            }
        }
    }
}
