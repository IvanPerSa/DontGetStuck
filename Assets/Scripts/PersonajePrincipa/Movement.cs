using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadNormal = 5f;
    public float velocidadCorrer = 7f;
    public float fuerzaSalto = 12f;
    public float fuerzaDobleSalto = 6f;
    public float velocidadDeslizamientoPared = 2f;

    private Rigidbody2D rb;
    private bool enSuelo;
    private bool enPared;
    private bool puedeSaltar = true;
    private bool haDadoDobleSalto = false;

    public Transform comprobadorSuelo;
    public LayerMask capaSuelo;
    private float radioComprobacion = 0.2f;

    private Animator anim;
    private float moveInput;
   public bool puedeDobleSalto = false;
    public float initJumpTimer;
    float jumpTimer = 1.2f;
    bool startTimer = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpTimer = initJumpTimer;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (enSuelo == true)
        {
            puedeDobleSalto = false;
            // DetectarColisiones();
            Movimiento();
            Saltar();
            Animaciones();
        }
        else
        {
            if (startTimer == true)
            {
                puedeDobleSalto = true;
                jumpTimer -= Time.deltaTime;
                
                if(haDadoDobleSalto == true)
                    anim.SetBool("IsDoubleJumping", false);
                DobleSalto();
                if (jumpTimer < 0)
                {
                    startTimer = false;
                    puedeDobleSalto = false;
                    haDadoDobleSalto=false;
                    jumpTimer= initJumpTimer;
                }
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
       /* if (enSuelo) // Si está en el suelo, puede saltar de nuevo y hacer doble salto
        {
            puedeSaltar = true;
            haDadoDobleSalto = false;
        }*/
       
            if ( Input.GetButtonDown("Jump"))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
                startTimer = true;
                anim.SetBool("Jumping", true);
                //puedeDobleSalto = true;
            }
            else
            {
            anim.SetBool("Jumping", false);
            }
           
        
    }
    void DobleSalto()
    {
        if (puedeDobleSalto && Input.GetButtonDown("Jump"))
        {
            if (!haDadoDobleSalto)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaDobleSalto);
                haDadoDobleSalto = true;
                anim.SetBool("IsDoubleJumping", true);
            }
           
            
              
           
           // puedeDobleSalto = false;
        }
    }

   /* void DetectarColisiones()
    {
        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioComprobacion, capaSuelo);
    }*/

    void Animaciones()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        anim.SetBool("EnSuelo", enSuelo);

        /*if (!enSuelo && rb.linearVelocity.y > 0.1f)
        {
            anim.SetFloat("Jump", 1);
        }*/
        /*else if (!enSuelo && rb.linearVelocity.y < -0.1f)
        {
            anim.SetFloat("Jump", -1);
        }
        else
        {
            anim.SetFloat("Jump", 0);
        }*/

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1.626259f, transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1.626259f, transform.localScale.y, transform.localScale.z);
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelos")
        {
            Debug.Log("is landin");
            enSuelo = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelos")
        {
            Debug.Log("no is landin");
            enSuelo = false;
        }
    }*/

   public bool setGround(bool ground)
    {
        return enSuelo = ground;
    }

}

