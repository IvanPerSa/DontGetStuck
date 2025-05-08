using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class RestartLevel : MonoBehaviour
{
    // Método que reinicia el nivel
    public void RestartCurrentLevel()
    {
        // Obtener el nombre de la escena actual y cargarla nuevamente
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);

        Time.timeScale = 1f;

    }


}
