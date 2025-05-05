using UnityEngine;

public class TextMaskDude4 : MonoBehaviour
{
    public GameObject TextMaskDudeVagabundo; // Referencia al Canvas


    private void Start()
    {
        if (TextMaskDudeVagabundo != null)
        {
            TextMaskDudeVagabundo.SetActive(false); // Desactiva el Canvas al inicio
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal")) // Asegúrate de que el personaje tenga el tag "Princi"
        {
            TextMaskDudeVagabundo.SetActive(true); // Activa el Canvas
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal"))
        {
            TextMaskDudeVagabundo.SetActive(false); // Desactiva el Canvas al salir
        }

    }
}
