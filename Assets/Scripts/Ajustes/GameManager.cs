using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool tutorialCompletado = false;

    public GameObject botonLevels; // ← asigna esto en el inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (tutorialCompletado && botonLevels != null)
        {
            botonLevels.SetActive(true);
            tutorialCompletado = false; // opcional: para que no se repita
        }
    }
}
