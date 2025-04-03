using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad del movimiento
    public float alturaMax = 3f; // Altura máxima
    public float alturaMin = 0f; // Altura mínima

    private bool subiendo = true;

    void Update()
    {
        Vector3 posicion = transform.position;

        if (subiendo)
        {
            posicion.y += velocidad * Time.deltaTime;
            if (posicion.y >= alturaMax)
                subiendo = false;
        }
        else
        {
            posicion.y -= velocidad * Time.deltaTime;
            if (posicion.y <= alturaMin)
                subiendo = true;
        }

        transform.position = posicion;
    }

    // ✅ Hacer que el jugador "pegue" a la plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // ❌ Cuando el jugador salta o cae, lo "despegamos"
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
