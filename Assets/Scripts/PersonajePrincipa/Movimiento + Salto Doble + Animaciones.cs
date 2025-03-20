using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public float fuerzaSalto = 7f; // Fuerza del salto
    public int maxSaltos = 2; // N�mero m�ximo de saltos (doble salto)

    private Rigidbody2D rb;
    private Animator animator;
    private bool enSuelo;
    private int contadorSaltos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Mover();
        Saltar();
        ActualizarAnimaciones();
    }

    void Mover()
    {
        float movimiento = Input.GetAxis("Horizontal"); // Movimiento con A/D o Flechas
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        // Voltear el personaje seg�n la direcci�n
        if (movimiento > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movimiento < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && contadorSaltos < maxSaltos)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            contadorSaltos++;
        }
    }

    void ActualizarAnimaciones()
    {
        animator.SetFloat("Velocidad", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("EnSuelo", enSuelo);
    }

    // Detecta si toca el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
            contadorSaltos = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}
