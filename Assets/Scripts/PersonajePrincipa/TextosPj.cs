using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarTexto : MonoBehaviour
{
    public GameObject textoCanvas; // Objeto de texto a mostrar
    public string tagJugador = "PersonajePrincipal"; // Tag del jugador

    private void Start()
    {
        if (textoCanvas != null)
        {
            textoCanvas.SetActive(false); // Oculta el texto al iniciar
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto de texto en el script MostrarTexto.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador) && textoCanvas != null)
        {
            textoCanvas.SetActive(true); // Mostrar texto
            Debug.Log("Jugador ha entrado en el área.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagJugador) && textoCanvas != null)
        {
            textoCanvas.SetActive(false); // Ocultar texto
            Debug.Log("Jugador ha salido del área.");
        }
    }
}
