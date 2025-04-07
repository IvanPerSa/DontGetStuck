using UnityEngine;

public class DesaparecerPincho : MonoBehaviour
{
    GameObject princi;
    // Método que se llama cuando colisiona con el personaje

    private void Start()
    {
        princi = GameObject.Find("Princi");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Princi"
        if (collision.gameObject.CompareTag("PersonajePrincipal"))
        {
            princi.GetComponent<Animator>().SetBool("alive",false);
            princi.GetComponent<MovimientoPersonaje>().isAlive(false);
          
        }
    }
}
    