using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class GoToMainMenu : MonoBehaviour
{
    // Método que lleva al jugador a la página principal
    public void GoToMainPage()
    {
        // Guarda que el tutorial fue completado (si es relevante aquí)
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save();

        // Cargar la escena principal
        SceneManager.LoadScene("PaginaPrincipal");  // Asegúrate de que el nombre sea EXACTAMENTE como en el Build Settings

        // Restablecer el tiempo por si el juego estaba pausado
        Time.timeScale = 1f;
    }
}
