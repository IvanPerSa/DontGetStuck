using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas

public class CambiarTuto : MonoBehaviour
{
    // Método para cambiar la escena
    public void CambiarEscena()
    {
        Debug.Log("EscenaTuto");
        SceneManager.LoadScene("EscenaTuto");
       
    }
}

