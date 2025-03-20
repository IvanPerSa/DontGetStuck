using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadNormal = 5f;
    public float velocidadCorrer = 7f;
    public float fuerzaSalto = 7f;
    public float fuerzaDobleSalto = 5f;
    public float velocidadDeslizamientoPared = 2f;

    private Rigidbody2D rb;
    private bool enSuelo, enPared;
    private bool puedeSaltar = true;
    private bool isDoubleJumping = false;

    private Animator anim;
    private float moveInput;

    public Transform comprobadorSuelo, comprobadorPared;
    public LayerMask sueloLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (comprobadorSuelo == null || comprobadorPared == null)
        {
            Debug.LogError("?? ERROR: No se han asignado comprobadorSuelo o comprobadorPared en el Inspector.");
        }
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        DetectarColisiones();
        Movimiento();
        Saltar();
        Animaciones();
    }

    void Movimiento()
    {
        float velocidad = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadNormal;
        rb.linearVelocity = new Vector2(moveInput * velocidad, rb.linearVelocity.y);

        if (moveInput > 0) transform.localScale = new Vector3(1.626259f, transform.localScale.y, transform.localScale.z);
        else if (moveInput < 0) transform.localScale = new Vector3(-1.626259f, transform.localScale.y, transform.localScale.z);
    }

    void Saltar()
    {
        if (enSuelo)
        {
            puedeSaltar = true;
            isDoubleJumping = false; // ? Se resetea correctamente al tocar el suelo
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (enSuelo)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
                puedeSaltar = false;
                Debug.Log("?? Salto normal!");
            }
            else if (!enSuelo && !isDoubleJumping)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaDobleSalto);
                isDoubleJumping = true; // ? Solo se activa despu�s del primer salto
                Debug.Log("?? DOBLE SALTO!");
            }
            else if (enPared)
            {
                float direccionSalto = transform.localScale.x > 0 ? -1 : 1;
                rb.linearVelocity = new Vector2(direccionSalto * velocidadNormal, fuerzaDobleSalto);
                puedeSaltar = false;
                Debug.Log("????? Salto en pared!");
            }
        }

        // Deslizamiento en pared si est� toc�ndola y cayendo
        if (enPared && !enSuelo && rb.linearVelocity.y < 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -velocidadDeslizamientoPared);
        }
    }

    void DetectarColisiones()
    {
        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, 0.2f, sueloLayer);
        enPared = Physics2D.OverlapCircle(comprobadorPared.position, 0.2f, sueloLayer);

        Debug.Log($"?? enSuelo: {enSuelo}, ?? enPared: {enPared}, ?? Doble Salto Usado: {isDoubleJumping}");
    }

    void Animaciones()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        anim.SetBool("Corriendo", Mathf.Abs(rb.linearVelocity.x) > 0.1f);
        anim.SetFloat("Jump", rb.linearVelocity.y > 0.1f ? 1 : (rb.linearVelocity.y < -0.1f ? -1 : 0));
    }
}
