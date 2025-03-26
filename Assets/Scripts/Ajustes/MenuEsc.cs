using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escenas
using UnityEngine.UI; // Necesario para trabajar con los botones UI

public class PauseMenuManager : MonoBehaviour
{
    public GameObject MenuEsc;       // Referencia al Panel que contiene el menú de pausa
    public Camera mainCamera;        // Referencia a la cámara principal
    public Vector3 offset = new Vector3(0, 0, 5f); // Desplazamiento del canvas desde la cámara

    private bool isPaused = false;   // Estado del menú de pausa

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // Si no se asignó una cámara, usamos la cámara principal
        }

        // Desactivar el menú de pausa al 
        isPaused = false;
    }

    void Update()
    {
        // Activar/desactivar el menú de pausa con la tecla ESC
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
        }

        // Hacer que el menú siga a la cámara principal
        if (mainCamera != null)
        {
            MenuEsc.transform.position = mainCamera.transform.position + offset;
            MenuEsc.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward); // Mirar hacia la cámara
        }
    }

    // Función para abrir el menú de pausa
    public void OpenPauseMenu()
    {
        MenuEsc.SetActive(true);  // Activar el menú de pausa
        Time.timeScale = 0f;      // Pausar el juego
        isPaused = true;          // Cambiar el estado de pausa
    }

    // Función para cerrar el menú de pausa
    public void ClosePauseMenu()
    {
        MenuEsc.SetActive(false);  // Desactivar el menú de pausa
        Time.timeScale = 1f;       // Reanudar el juego
        isPaused = false;          // Cambiar el estado de pausa
    }

    // Función para ir al menú principal
    public void GoToPaginaPrincipal()
    {
        SceneManager.LoadScene("PaginaPrincipal");  // Cargar la escena "PaginaPrincipal"
    }

    // Función para reiniciar el nivel
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reiniciar la escena actual
    }
}
