using UnityEngine;

public class MovimientoPincho : MonoBehaviour
{
    public float puntoX1 = -6f; // Izquierda (ajustado para el borde del suelo)
    public float puntoX2 = -2.5f; // Derecha (justo antes del hueco)
    public float velocidad = 2f;

    private float objetivoX;
    private float yFijo;

    void Start()
    {
        objetivoX = puntoX2;
        yFijo = transform.position.y; // Guarda la altura actual
    }

    void Update()
    {
        // Movimiento horizontal solo en X
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.MoveTowards(posicionActual.x, objetivoX, velocidad * Time.deltaTime);
        posicionActual.y = yFijo; // Fija la altura
        transform.position = posicionActual;

        // Cambiar de dirección al llegar a un extremo
        if (Mathf.Abs(transform.position.x - objetivoX) < 0.05f)
        {
            objetivoX = (objetivoX == puntoX1) ? puntoX2 : puntoX1;
        }
    }
}
