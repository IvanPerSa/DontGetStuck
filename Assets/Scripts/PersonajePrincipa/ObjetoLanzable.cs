using UnityEngine;

public class LevantarObjeto : MonoBehaviour
{
    public GameObject objetoLanzable; // El objeto que vamos a levantar
    private bool objetoEnMano = false;
    private Transform objetoOriginalParent;
    private Rigidbody2D rbObjeto;
    private SpriteRenderer spriteRenderer; // Para controlar el FlipX del objeto

    public float distanciaDelante = 2f; // Distancia a la que el objeto estará frente al personaje

    private Transform personaje; // El transform del personaje principal
    private Collider2D colliderObjeto; // Collider2D del objeto
    private Collider2D colliderPersonaje; // Collider2D del personaje

    void Start()
    {
        // Obtenemos el transform del personaje y el sprite renderer del objeto
        personaje = GameObject.FindWithTag("PersonajePrincipal").transform;
        spriteRenderer = objetoLanzable.GetComponent<SpriteRenderer>();
        rbObjeto = objetoLanzable.GetComponent<Rigidbody2D>();
        objetoOriginalParent = objetoLanzable.transform.parent; // El padre original del objeto
        colliderObjeto = objetoLanzable.GetComponent<Collider2D>(); // Obtenemos el Collider del objeto
        colliderPersonaje = personaje.GetComponent<Collider2D>(); // Obtenemos el Collider del personaje
    }

    void Update()
    {
        // Detectamos si el jugador presiona o suelta el botón E
        if (Input.GetKeyDown(KeyCode.E) && !objetoEnMano)
        {
            LevantarObjetoConMano();
        }

        if (Input.GetKey(KeyCode.E) && objetoEnMano)
        {
            MoverObjetoConPersonaje();
        }

        if (Input.GetKeyUp(KeyCode.E) && objetoEnMano)
        {
            SoltarObjeto();
        }
    }

    // Levantamos el objeto y lo colocamos frente al personaje

    void LevantarObjetoConMano()
    {
        // Ponemos el objeto en la mano del jugador (como hijo del jugador)
        objetoLanzable.transform.SetParent(personaje);

        // Lo posicionamos justo frente al personaje (dependiendo de la dirección)
        Vector3 posicionFrente = personaje.position + personaje.right * distanciaDelante;
        objetoLanzable.transform.position = posicionFrente;

        // Desactivamos la física para que el objeto no se vea afectado por la gravedad
        rbObjeto.isKinematic = true;

        // Desactivamos las colisiones entre el personaje y la caja
        Physics2D.IgnoreCollision(colliderObjeto, colliderPersonaje, true);

        // Hacemos que la caja no colisione con otros objetos durante el levantamiento
        colliderObjeto.isTrigger = true; // Activa el Trigger para que no interfiera con colisiones

        objetoEnMano = true;
    }

    // Movemos el objeto con el personaje mientras se mantenga presionado E
    void MoverObjetoConPersonaje()
    {
        // Hacemos flipX con el personaje
        spriteRenderer.flipX = personaje.localScale.x < 0;

        // Mover el objeto para que esté siempre delante del personaje
        Vector3 frente = personaje.right * distanciaDelante; // Vector hacia adelante
        objetoLanzable.transform.position = personaje.position + frente;
    }

    // Soltamos el objeto y lo dejamos caer al suelo, colocándolo justo frente al personaje
    void SoltarObjeto()
    {
        // Deshacemos el parent y dejamos que la física tome el control
        objetoLanzable.transform.SetParent(objetoOriginalParent);

        // Reactivamos la física, lo que permitirá que el objeto caiga con gravedad
        rbObjeto.isKinematic = false;

        // Colocamos el objeto frente al personaje en la dirección en la que mira
        Vector3 frente = personaje.right * distanciaDelante; // Dirección hacia el frente
        objetoLanzable.transform.position = personaje.position + frente;

        // Reactivamos las colisiones entre el personaje y la caja
        Physics2D.IgnoreCollision(colliderObjeto, colliderPersonaje, false);

        // Desactivamos el trigger para que la caja interactúe físicamente con el entorno
        colliderObjeto.isTrigger = false;

        objetoEnMano = false;
    }
}
