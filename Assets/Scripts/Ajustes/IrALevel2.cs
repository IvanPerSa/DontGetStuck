using UnityEngine;
using UnityEngine.SceneManagement;

public class IrA2rNivel : MonoBehaviour
{
    public void Cargar2rNivel()
    {
        SceneManager.LoadScene("2ndNivel");

        Time.timeScale = 1f;
    }
}
