using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void IrAPantallaPruebas()
    {
        Time.timeScale = 1f; // Asegura que el tiempo esté activo
        SceneManager.LoadScene("Pruebas");
    }
}
