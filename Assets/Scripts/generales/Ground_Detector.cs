using UnityEngine;

public class Ground_Detector : MonoBehaviour
{
    public MovimientoPersonaje movimientoPersonaje;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelos") || collision.CompareTag("Interactuable"))
        {
            movimientoPersonaje.setGround(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelos") || collision.CompareTag("Interactuable"))
        {
            movimientoPersonaje.setGround(false);
        }
    }
}
