using UnityEngine;

public class DisparoController : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 10f;
    public int maxProyectiles = 3;  // Número máximo de proyectiles activos a la vez

    private GameObject[] proyectilesActivos;

    void Start()
    {
        // Inicializamos el arreglo de proyectiles activos
        proyectilesActivos = new GameObject[maxProyectiles];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Buscar el primer espacio libre para un proyectil
        for (int i = 0; i < maxProyectiles; i++)
        {
            if (proyectilesActivos[i] == null)  // Si no hay un proyectil en esta posición
            {
                // Instanciar el proyectil
                GameObject nuevoProyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);
                proyectilesActivos[i] = nuevoProyectil;

                // Dirección del personaje
                float direccion = transform.localScale.x >= 0 ? 1f : -1f;

                // Escalar mirando la dirección
                Vector3 escala = nuevoProyectil.transform.localScale;
                escala.x = Mathf.Abs(escala.x) * direccion;
                nuevoProyectil.transform.localScale = escala;

                // Rotar sprite 90 grados
                nuevoProyectil.transform.Rotate(0f, 0f, -90f * direccion);

                // Mover
                Rigidbody2D rb = nuevoProyectil.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = new Vector2(fuerzaDisparo * direccion, 0f);
                }

                // Conectar el controlador de disparo
                Proyectil script = nuevoProyectil.GetComponent<Proyectil>();
                if (script != null)
                {
                    script.controladorDisparo = this;
                }
                break;  // Salir del bucle después de disparar un proyectil
            }
        }
    }

    public void LiberarProyectil(GameObject proyectil)
    {
        // Buscar el proyectil en el array y liberar ese espacio
        for (int i = 0; i < maxProyectiles; i++)
        {
            if (proyectilesActivos[i] == proyectil)
            {
                proyectilesActivos[i] = null;
                break;
            }
        }
    }
}
