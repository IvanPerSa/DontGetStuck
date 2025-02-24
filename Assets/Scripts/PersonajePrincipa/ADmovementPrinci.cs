using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidad normal
    public float runMultiplier = 1.5f; // Multiplicador de velocidad al correr
    public float jumpForce = 10f; // Fuerza del salto
    public int maxJumps = 2; // Saltos máximos normales
    public float wallJumpForceX = 5f; // Fuerza lateral del wall jump
    public float wallSlideSpeed = 2f; // Velocidad al deslizar en la pared

    [SerializeField] private Transform wallCheck; // Punto para detectar si toca una pared
    public float wallCheckRadius = 0.2f; // Radio de detección de pared
    public LayerMask whatIsWall; // Para detectar paredes

    private Rigidbody2D rb;
    private int jumpsLeft; // Saltos restantes normales
    private bool isGrounded; // Si está tocando el suelo
    private bool isTouchingWall; // Si está tocando una pared
    private float moveInput;
    private bool isWallSliding; // Si está deslizándose en una pared
    private bool canWallJump; // Si puede hacer wall jump

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps; // Empieza con todos los saltos disponibles

        // Asignar wallCheck automáticamente si no está asignado en el Inspector
        if (wallCheck == null)
        {
            wallCheck = transform.Find("WallCheck");

            if (wallCheck == null)
            {
                Debug.LogError("No se encontró un objeto llamado 'WallCheck' como hijo del jugador. Asegúrate de crearlo en la jerarquía o asignarlo en el Inspector.");
            }
        }
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // A (-1) / D (1)

        // Verificar si wallCheck está asignado antes de usarlo
        if (wallCheck == null)
        {
            Debug.LogError("wallCheck no ha sido asignado en el Inspector o no se encontró en la jerarquía.");
            return;
        }

        // Salto normal (Espacio o W)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && (jumpsLeft > 0 || canWallJump))
        {
            Jump();
        }

        // Detectar si toca una pared
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        // Activar wall slide si toca una pared y está cayendo
        isWallSliding = isTouchingWall && !isGrounded && rb.velocity.y < 0;

        // Si está en la pared, permite un wall jump sin resetear el doble salto
        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed); // Hace que se deslice en la pared
            canWallJump = true;
        }
    }

    void FixedUpdate()
    {
        // Correr si se mantiene Shift
        float currentSpeed = speed * (Input.GetKey(KeyCode.LeftShift) ? runMultiplier : 1f);

        // Aplicar movimiento
        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (canWallJump && isWallSliding)
        {
            rb.velocity = new Vector2(-moveInput * wallJumpForceX, jumpForce);
            canWallJump = false; // Evita saltos infinitos en la pared
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Resetear velocidad en Y para evitar acumulaciones
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsLeft--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.root.gameObject.name == "ControladorColisiones")
        {
            isGrounded = true;
            jumpsLeft = maxJumps; // Resetea el doble salto
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.root.gameObject.name == "ControladorColisiones")
        {
            isGrounded = false;
        }
    }
}
