using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnTrigger : MonoBehaviour
{
    public Text holaText; // Referencia al Text llamado "Hola"
    public string playerTag = "PersonajePrincipal"; // Asegúrate de que "PersonajePrincipal" es el tag del personaje principal

    void Start()
    {
        if (holaText != null)
            holaText.gameObject.SetActive(false); // Ocultar el texto al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            holaText.gameObject.SetActive(true); // Mostrar el texto
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            holaText.gameObject.SetActive(false); // Ocultar el texto
        }
    }
}
