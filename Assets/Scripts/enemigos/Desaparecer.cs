using UnityEngine;

public class DesaparecerPincho : MonoBehaviour
{
    private GameObject princi;
    private ContadorMuertes contadorMuertes;
    public GameObject uiManager;
    private void Start()
    {
        princi = GameObject.Find("Princi");
        uiManager = GameObject.Find("MuertesUi"); // El GameObject con ContadorMuertes.cs
        if (uiManager != null)
        {
            contadorMuertes = uiManager.GetComponent<ContadorMuertes>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PersonajePrincipal"))
        {
            princi.GetComponent<Animator>().SetBool("alive", false);
            princi.GetComponent<MovimientoPersonaje>().isAlive(false);

            if (contadorMuertes != null)
            {
                contadorMuertes.SumarMuerte();
            }
        }
    }
}
