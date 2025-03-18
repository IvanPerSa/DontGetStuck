using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    private Vector3 posicionInicial; // Guardará la posición inicial del jugador

    void Start()
    {
        posicionInicial = transform.position; // Guarda la posición inicial al iniciar
    }

    public void ReiniciarPosicion()
    {
        transform.position = posicionInicial; // Vuelve al inicio
        Debug.Log("El jugador ha sido reiniciado.");
    }
}
