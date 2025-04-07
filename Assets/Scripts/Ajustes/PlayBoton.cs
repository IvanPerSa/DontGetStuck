using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    // Referencia al Canvas que quieres ocultar
    public GameObject menuEsc;

    // Método que se llama cuando el botón es presionado
    public void CloseMenuOnClick()
    {
        // Desactivar el Canvas
        menuEsc.SetActive(false);
    }
}
