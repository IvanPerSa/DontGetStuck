using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBrillo : MonoBehaviour
{
    public Slider slider;
    public Image panelBrillo;

    void Start()
    {
        // Asegurar que el brillo se cargue desde el BrilloManager
        slider.value = BrilloManager.instancia.GetBrillo();
        AplicarBrillo(slider.value);

        // Suscribirse al evento del slider si no lo está
        slider.onValueChanged.AddListener(ChangeSlider);
    }

    public void ChangeSlider(float valor)
    {
        BrilloManager.instancia.SetBrillo(valor);
        AplicarBrillo(valor);
    }

    void AplicarBrillo(float valor)
    {
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, valor);
    }
}
