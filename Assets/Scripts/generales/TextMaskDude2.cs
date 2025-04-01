using UnityEngine;

public class TextMaskDude : MonoBehaviour
{
    public GameObject TextMaskVagabundo; // Referencia al Canvas


    private void Start()
    {
        if (TextMaskVagabundo != null)
        {
            TextMaskVagabundo.SetActive(false); // Desactiva el Canvas al inicio
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal")) // Asegúrate de que el personaje tenga el tag "Princi"
        {
            TextMaskVagabundo.SetActive(true); // Activa el Canvas
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal"))
        {
            TextMaskVagabundo.SetActive(false); // Desactiva el Canvas al salir
        }

    }
}
