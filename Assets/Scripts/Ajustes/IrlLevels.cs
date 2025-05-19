using UnityEngine;
using UnityEngine.SceneManagement;

public class IrLevels : MonoBehaviour
{
    public void OnPressedLevels()
    {
       

        // Cargar la escena principal
        SceneManager.LoadScene("SelectoNiveles");
    }
}
