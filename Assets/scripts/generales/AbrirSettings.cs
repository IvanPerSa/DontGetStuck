using UnityEngine;

public class ActivarCanvas : MonoBehaviour
{
    public GameObject settingCanvas; // Asignar el canvas desde el Inspector

    public void MostrarCanvas()
    {
        if (settingCanvas != null)
        {
            settingCanvas.SetActive(true); // Activa el Canvas
        }
        else
        {
            Debug.LogError("El Canvas no está asignado en el Inspector.");
        }
    }
}
