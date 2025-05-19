using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public void OnTutorialComplete()
    {
        // Guardamos que el tutorial ya fue completado
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save();

        // Cargar la escena principal
        SceneManager.LoadScene("SelectoNiveles");
    }
}
