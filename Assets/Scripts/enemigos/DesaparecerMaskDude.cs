using UnityEngine;

public class TriggerMaskDude : MonoBehaviour
{
    public Animator animator; // Referencia al Animator
    public bool IsOutside = false; // Variable que indica si está fuera del trigger


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal")) // Asegúrate de que el personaje tenga este tag
        {
            IsOutside = true;
        }
    }
}