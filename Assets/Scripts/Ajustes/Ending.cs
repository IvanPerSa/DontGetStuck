using UnityEngine;

public class ActivarMenuEnding : MonoBehaviour
{
    public GameObject menuEnding; // Arrástralo desde el inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PersonajePrincipal"))
        {
            if (menuEnding != null)
            {
                menuEnding.SetActive(true);
                Time.timeScale = 0;

            }
            else
            {
                Debug.LogWarning("No se ha asignado el objeto MenuEnding.");
            }
        }
    }
}
