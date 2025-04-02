using UnityEngine;

public class TextMaskDude3 : MonoBehaviour
{
    public GameObject TextMaskAlpinista; // Referencia al Canvas


    private void Start()
    {
        if (TextMaskAlpinista != null)
        {
            TextMaskAlpinista.SetActive(false); // Desactiva el Canvas al inicio
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal")) // Asegúrate de que el personaje tenga el tag "Princi"
        {
            TextMaskAlpinista.SetActive(true); // Activa el Canvas
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal"))
        {
            TextMaskAlpinista.SetActive(false); // Desactiva el Canvas al salir
        }

    }
}
