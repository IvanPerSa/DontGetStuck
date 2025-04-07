using UnityEngine;

public class PinchoMovimiento : MonoBehaviour
{
    public float velocidad = 5f;           // Velocidad de movimiento
    public float desplazamiento = 0.5f;    // Cuánto se mueve arriba y abajo
    public int orden = 0;                  // Índice del pincho (lo pondrás tú manualmente)

    private Vector3 posicionInicial;
    private float direccion;

    void Start()
    {
        posicionInicial = transform.position;

        // Alternar dirección inicial: si el orden es par, sube primero; si es impar, baja
        direccion = (orden % 2 == 0) ? 1f : -1f;
    }

    void Update()
    {
        float movimiento = Mathf.Sin(Time.time * velocidad + orden) * desplazamiento;
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y + movimiento * direccion, posicionInicial.z);
    }
}

