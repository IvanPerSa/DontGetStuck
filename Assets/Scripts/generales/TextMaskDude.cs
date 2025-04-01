using UnityEngine;

public class ActivarTexto : MonoBehaviour
{
    public GameObject TextMask; // Referencia al Canvas


    private void Start()
    {
        if (TextMask != null)
        {
            TextMask.SetActive(false); // Desactiva el Canvas al inicio
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal")) // Asegúrate de que el personaje tenga el tag "Princi"
        {
            TextMask.SetActive(true); // Activa el Canvas
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal"))
        {
            TextMask.SetActive(false); // Desactiva el Canvas al salir
        }

    }
}
