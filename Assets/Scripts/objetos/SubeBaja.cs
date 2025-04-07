using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    public float velocidad = 2f;       // Velocidad de la plataforma
    public float alturaMax = 3f;       // Altura máxima
    public float alturaMin = 0f;       // Altura mínima

    private bool subiendo = true;

    void Update()
    {
        float movimiento = velocidad * Time.deltaTime;
        Vector3 posicion = transform.position;

        if (subiendo)
        {
            posicion.y += movimiento;
            if (posicion.y >= alturaMax)
            {
                posicion.y = alturaMax;
                subiendo = false;
            }
        }
        else
        {
            posicion.y -= movimiento;
            if (posicion.y <= alturaMin)
            {
                posicion.y = alturaMin;
                subiendo = true;
            }
        }

        transform.position = posicion;
    }
}
