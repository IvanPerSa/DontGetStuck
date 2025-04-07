using UnityEngine;

public class PauseGameOnEnding : MonoBehaviour
{
    // Referencia al Canvas del MenuFinal
    public GameObject MenuEnding;

    // Método que se llama cuando se detecta la colisión (trigger en 2D)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si el objeto que colisionó tiene el nombre "ending"
        if (other.gameObject.name == "Princi")
        {

            MenuEnding.SetActive(true);
         
            Time.timeScale = 0f;

            
        }
    }
}
