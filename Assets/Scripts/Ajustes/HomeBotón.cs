using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class GoToMainMenu : MonoBehaviour
{
    // Método que lleva al jugador a la página principal
    public void GoToMainPage()
    {
        // Asegúrate de que el nombre de la escena sea exacto
        SceneManager.LoadScene("PaginaPrincipal");  // Usa el nombre exacto de tu escena con el espacio

        Time.timeScale = 1f;


    }
}
