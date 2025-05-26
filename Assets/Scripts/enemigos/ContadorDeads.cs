using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContadorMuertes : MonoBehaviour
{
    public TextMeshProUGUI textoContador; // Arrástralo en el Inspector
    private int muertes = 0;

    public void SumarMuerte()
    {
       
        muertes++;
        Debug.Log(muertes);
        textoContador.text ="X: "+ muertes.ToString();
    }
}
