using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialBoton : MonoBehaviour
{
    public void TerminarTutorial()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.tutorialCompletado = true;  // Le dices al GameManager que el tutorial terminó
        }
        SceneManager.LoadScene("PaginaPrincipal"); // Cargas la escena principal
    }
}
