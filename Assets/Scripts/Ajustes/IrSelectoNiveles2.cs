using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarSelecto2 : MonoBehaviour
{
    public void CargarSelectos2()
    {
        SceneManager.LoadScene("SelectoNiveles2");

        Time.timeScale = 1f;
    }
}

