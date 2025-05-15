using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextScreen : MonoBehaviour
{
    public void GotoNext()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.tutorialCompletado = true;
        }
        else
        {
            Debug.LogWarning("GameManager no encontrado!");
        }
        SceneManager.LoadScene("SelectoNiveles"); // Asegúrate que el nombre es correcto
    }
}
