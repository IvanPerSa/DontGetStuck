using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadNormal = 5f;
    public float velocidadCorrer = 7f;
    public float fuerzaSalto = 12f;

    private Rigidbody2D rb;
    private bool enSuelo = false;
    private bool alive = true;

    private Animator anim;
    private float moveInput;

    public float initCounter;
    private float counter;
    private Vector2 checkpointPos;

    public GameObject checkpointMarkerPrefab;
    private GameObject currentCheckpointMarker;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        counter = initCounter;

        bool modoFacilActivo = PlayerPrefs.GetInt("ModoFacil", 0) == 1;
        checkpointPos = GameObject.FindGameObjectWithTag("initPos").transform.position;

        if (modoFacilActivo)
        {
            Debug.Log("Modo Fácil activo: checkpoints habilitados");
        }
        else
        {
            Debug.Log("Modo Fácil desactivado");
        }
    }

    void Update()
    {
        if (!alive)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                transform.position = checkpointPos;
                anim.SetBool("alive", true);
                counter = initCounter;
                alive = true;
            }
            return;
        }

        moveInput = Input.GetAxisRaw("Horizontal");
        Movimiento();

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            Saltar();
        }

        if (Input.GetKeyDown(KeyCode.C) && PlayerPrefs.GetInt("ModoFacil", 0) == 1)
        {
            checkpointPos = transform.position;
            Debug.Log("Checkpoint guardado en: " + checkpointPos);

            if (currentCheckpointMarker == null && checkpointMarkerPrefab != null)
            {
                currentCheckpointMarker = Instantiate(checkpointMarkerPrefab, checkpointPos, Quaternion.identity);
            }
            else if (currentCheckpointMarker != null)
            {
                currentCheckpointMarker.transform.position = checkpointPos;
            }
        }

        Animaciones();
    }

    void Movimiento()
    {
        float velocidad = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadNormal;
        rb.linearVelocity = new Vector2(moveInput * velocidad, rb.linearVelocity.y);
    }

    void Saltar()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        anim.SetBool("Jumping", true);
    }

    void Animaciones()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));

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
        if (ground)
        {
            anim.SetBool("Jumping", false);
        }
    }

    public bool isAlive(bool state)
    {
        alive = state;
        return alive;
    }
}
