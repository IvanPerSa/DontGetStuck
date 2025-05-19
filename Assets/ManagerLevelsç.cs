using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public GameObject levelsButton; // asigna esto en el Inspector

    void Start()
    {
        // Si el tutorial fue completado, activa el botón e niveles
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 0)
        {
            levelsButton.SetActive(false);
        }
        else
        {
            levelsButton.SetActive(true); // por si quieres forzar que esté oculto
        }
    }
}
