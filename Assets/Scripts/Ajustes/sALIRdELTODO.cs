using UnityEngine;

public class CerrarJuego : MonoBehaviour
{
    public void Cerrar()
    {
#if UNITY_EDITOR
        // Cierra solo si estás en el editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Cierra en una build del juego
        Application.Quit();
#endif
    }
}
