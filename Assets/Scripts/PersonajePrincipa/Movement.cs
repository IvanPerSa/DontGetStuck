using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    // Referencias a los objetos con los BoxColliders
    public GameObject suelos;   // Objeto que contiene los colliders de los suelos
    public GameObject paredes;  // Objeto que contiene los colliders de las paredes
    public GameObject techo;    // Objeto que contiene los colliders del techo

    // Variables de movimiento
    public float velocidadNormal = 5f;
    public float velocidadCorrer = 7f;
    public float fuerzaSalto = 7f;
    public float fuerzaDobleSalto = 5f;
    public float velocidadDeslizamientoPared = 2f;

    private Rigidbody2D rb;
    private bool enSuelo;
    private bool enTecho;
    private bool puedeSaltar = true;
    private bool enPared;
    private bool corriendo;

    private bool isDoubleJumping = false; // Para saber si el jugador está realizando el doble salto

    private Animator anim; // Componente Animator

    // Para el flip del personaje
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Asegúrate de tener un componente Animator
    }

    void Update()
    {
        // Detecta el movimiento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");

        Movimiento();
        Saltar();
        DetectarColisiones();
        Animaciones();
    }

    void Movimiento()
    {
        // Detecta si el jugador está presionando Shift para correr
        corriendo = Input.GetKey(KeyCode.LeftShift);

        // Determina la velocidad dependiendo de si está corriendo o no
        float velocidad = corriendo ? velocidadCorrer : velocidadNormal;

        // Movimiento horizontal
        rb.linearVelocity = new Vector2(moveInput * velocidad, rb.linearVelocity.y);
    }

    void Saltar()
    {
        // Si el personaje está tocando el suelo, puede realizar un salto
        if (enSuelo)
        {
            puedeSaltar = true;  // Resetear el doble salto al tocar el suelo
            isDoubleJumping = false; // Resetear el estado de doble salto
        }

        // Si está en el suelo, permite el primer salto
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            puedeSaltar = false;
        }
        // Si está en el aire y no ha realizado el doble salto, permite el doble salto
        else if (!enSuelo && !isDoubleJumping && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaDobleSalto);
            isDoubleJumping = true; // Marcar que se ha hecho el doble salto
        }
        // Si está en la pared y presiona salto, realiza un wall jump
        else if (enPared && Input.GetButtonDown("Jump") && puedeSaltar)
        {
            rb.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * velocidadDeslizamientoPared, fuerzaDobleSalto);
            puedeSaltar = false;  // Restringir el doble salto hasta estar de nuevo en el suelo
        }
    }

    void DetectarColisiones()
    {
        // Detecta si el personaje está tocando el suelo
        enSuelo = DetectarColision(suelos);

        // Detecta si el personaje está tocando el techo
        enTecho = DetectarColision(techo);

        // Detecta si el personaje está tocando una pared
        enPared = DetectarColision(paredes);
    }

    bool DetectarColision(GameObject objeto)
    {
        // Comprobamos si el personaje está tocando el objeto que contiene los BoxColliders
        BoxCollider2D[] colliders = objeto.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D collider in colliders)
        {
            if (collider.IsTouching(GetComponent<Collider2D>()))
            {
                return true;  // Si está tocando cualquier collider, devolvemos true
            }
        }
        return false;  // Si no está tocando ninguno, devolvemos false
    }

    // Actualizar las animaciones
    void Animaciones()
    {
        // Animación de movimiento (Speed: detecta si se está moviendo en el eje X)
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));

        // Aquí detectamos si el jugador está moviéndose o no
        bool corriendo = Mathf.Abs(rb.linearVelocity.x) > 0.1f;  // Si se mueve horizontalmente

        // Cambiar la animación de "Idle" a "Run"
        anim.SetBool("Corriendo", corriendo);

        // Animación de salto (Jump: detecta si se está saltando o cayendo)
        if (!enSuelo && rb.linearVelocity.y > 0.1f) // Está saltando
        {
            anim.SetFloat("Jump", 1); // Salto
        }
        else if (!enSuelo && rb.linearVelocity.y < -0.1f) // Está cayendo
        {
            anim.SetFloat("Jump", -1); // Caída
        }
        else // En el suelo o en un estado neutral
        {
            anim.SetFloat("Jump", 0); // Estado neutral (en el suelo)
        }

        // Flip en el eje X para girar el personaje según la dirección de movimiento
        if (moveInput > 0)
        {
            // Mirar a la derecha (sin aplastar el sprite)
            transform.localScale = new Vector3(1.626259f, transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {
            // Mirar a la izquierda (sin aplastar el sprite)
            transform.localScale = new Vector3(-1.626259f, transform.localScale.y, transform.localScale.z);
        }
    }

}
