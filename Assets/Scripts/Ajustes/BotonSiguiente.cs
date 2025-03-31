using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class GotoNextScreen : MonoBehaviour
{
    // Método que lleva al jugador a la página principal
    public void GotoNext()
    {
        // Asegúrate de que el nombre de la escena sea exacto
        SceneManager.LoadScene("SelectoNiveles");  // Usa el nombre exacto de tu escena con el espacio
    }
}
