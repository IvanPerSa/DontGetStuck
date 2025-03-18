using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public float alturaMaxima = 5f;
    public float alturaMinima = 1f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float movimientoVertical = Mathf.PingPong(Time.time * velocidad, alturaMaxima - alturaMinima) + alturaMinima;
        transform.position = new Vector3(transform.position.x, movimientoVertical, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            VidaJugador vida = other.GetComponent<VidaJugador>();
            if (vida != null)
            {
                vida.ReiniciarPosicion(); // Llama a la función para reiniciar su posición
            }
        }
    }
}
