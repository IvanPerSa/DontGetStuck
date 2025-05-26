using UnityEngine;
using TMPro;

public class ContadorConTecla : MonoBehaviour
{
    public TextMeshProUGUI textoContador;
    public int valorActual = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (valorActual > 0)
            {
                valorActual--;
                ActualizarTexto();
            }
        }
    }

    void ActualizarTexto()
    {
        textoContador.text = valorActual.ToString();
    }
}
