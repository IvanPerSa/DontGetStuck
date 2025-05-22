using UnityEngine;
using UnityEngine.SceneManagement;

public class IrA1rNivel : MonoBehaviour
{
    public void Cargar1rNivel()
    {
        SceneManager.LoadScene("1rNivel");

        Time.timeScale = 1f;
    }
}
