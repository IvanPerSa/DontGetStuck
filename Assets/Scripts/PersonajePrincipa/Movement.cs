using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadNormal = 5f;
    public float velocidadCorrer = 7f;
    public float fuerzaSalto = 12f;
    public float fuerzaDobleSalto = 10f;

    private Rigidbody2D rb;
    private bool enSuelo;
    private bool haDadoDobleSalto = false;

    public Transform comprobadorSuelo;
    public LayerMask capaSuelo;
    private float radioComprobacion = 0.2f;

    private Animator anim;
    private float moveInput;
    public bool puedeDobleSalto = false;
    bool alive = true;
    public float initCounter;
    float counter = 1.2f;
    public Vector2 initPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        counter = initCounter;
    }

    void Update()
    {

        if (alive)
        {
            moveInput = Input.GetAxisRaw("Horizontal");

            // ✅ El personaje ahora puede moverse también en el aire
            Movimiento();

            // ✅ Detectar si está en el suelo
            bool estabaEnSuelo = enSuelo;
            enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioComprobacion, capaSuelo);

            if (enSuelo && !estabaEnSuelo)
            {
                haDadoDobleSalto = false; // ✅ Resetear el doble salto al tocar suelo
                anim.SetBool("Jumping", false);
                anim.SetBool("IsDoubleJumping", false);
            }

            Saltar();
            DobleSalto(); // ✅ Ahora esto se ejecuta siempre en Update()

            Animaciones();
        }

        else
        {
            counter -=Time.deltaTime;
            if(counter < 0)
            {
                
                this.gameObject.transform.position = initPos;
                anim.SetBool("alive", true);
                counter = initCounter;
                alive = true;
                
            }
        }
    }

    void Movimiento()
    {
        float velocidad = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadNormal;
        rb.linearVelocity = new Vector2(moveInput * velocidad, rb.linearVelocity.y);
    }

    void Saltar()
    {
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            anim.SetBool("Jumping", true);
        }
    }

    void DobleSalto()
    {
        // ✅ Ahora solo puede hacer doble salto si está en el aire y no lo ha usado aún
        if (!enSuelo && !haDadoDobleSalto && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaDobleSalto);
            haDadoDobleSalto = true; // ✅ Evita saltos infinitos en el aire
            anim.SetBool("IsDoubleJumping", true);
        }
    }

    void Animaciones()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        anim.SetBool("EnSuelo", enSuelo);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1.626259f, transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1.626259f, transform.localScale.y, transform.localScale.z);
        }
    }

    public void setGround(bool ground)
    {
        enSuelo = ground;
        if (enSuelo)
        {
            haDadoDobleSalto = false; // ✅ Se reinicia el doble salto al tocar el suelo
        }
    }
    public bool isAlive(bool state)
    {
        return alive = state;
    }
}