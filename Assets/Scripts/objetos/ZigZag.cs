using UnityEngine;
using System.Collections;

public class ZigZag : MonoBehaviour
{
    public float velocidad = 10f;
    public float alturaMax = -21f;
    public float alturaMin = -60f;

    public float amplitudLateral = 2f;
    public float frecuenciaLateral = 2f;

    public float destinoIzquierdaX = 40f;

    public float amplitudVerticalZigZag = 1.7f;
    public float frecuenciaVerticalZigZag = 2f;

    private enum Estado { Bajando, EsperaAntesIzquierda, Izquierda, EsperaAntesDerecha, Derecha, EsperaAntesSubida, Subiendo }
    private Estado estadoActual = Estado.Bajando;

    private float tiempo = 0f;
    private float xInicio;
    private float desplazamientoAleatorio;

    private bool esperando = false;

    void Start()
    {
        xInicio = transform.position.x;
        desplazamientoAleatorio = Random.Range(0f, 100f);
    }

    void Update()
    {
        if (esperando) return;

        Vector3 pos = transform.position;
        float delta = velocidad * Time.deltaTime;

        switch (estadoActual)
        {
            case Estado.Bajando:
                pos.y = Mathf.MoveTowards(pos.y, alturaMin, delta);
                tiempo += Time.deltaTime;
                pos.x = xInicio + Mathf.Sin(tiempo * frecuenciaLateral) * amplitudLateral;

                if (Mathf.Approximately(pos.y, alturaMin))
                {
                    StartCoroutine(CambiarEstadoTrasEspera(Estado.Izquierda));
                    estadoActual = Estado.EsperaAntesIzquierda;
                }
                break;

            case Estado.Izquierda:
                pos.x = Mathf.MoveTowards(pos.x, destinoIzquierdaX, delta);
                tiempo += Time.deltaTime;
                pos.y = alturaMin + Mathf.Sin((tiempo + desplazamientoAleatorio) * frecuenciaVerticalZigZag) * amplitudVerticalZigZag;

                if (Mathf.Approximately(pos.x, destinoIzquierdaX))
                {
                    StartCoroutine(CambiarEstadoTrasEspera(Estado.Derecha));
                    estadoActual = Estado.EsperaAntesDerecha;
                }
                break;

            case Estado.Derecha:
                pos.x = Mathf.MoveTowards(pos.x, xInicio, delta);
                tiempo += Time.deltaTime;
                pos.y = alturaMin + Mathf.Sin((tiempo + desplazamientoAleatorio) * frecuenciaVerticalZigZag) * amplitudVerticalZigZag;

                if (Mathf.Approximately(pos.x, xInicio))
                {
                    StartCoroutine(CambiarEstadoTrasEspera(Estado.Subiendo));
                    estadoActual = Estado.EsperaAntesSubida;
                }
                break;

            case Estado.Subiendo:
                pos.y = Mathf.MoveTowards(pos.y, alturaMax, delta);
                tiempo += Time.deltaTime;
                pos.x = xInicio + Mathf.Sin(tiempo * frecuenciaLateral) * amplitudLateral;

                if (Mathf.Approximately(pos.y, alturaMax))
                {
                    StartCoroutine(CambiarEstadoTrasEspera(Estado.Bajando));
                }
                break;
        }

        transform.position = pos;
    }

    IEnumerator CambiarEstadoTrasEspera(Estado siguiente)
    {
        esperando = true;
        yield return new WaitForSeconds(0.4f); // Ajusta aquí el tiempo de espera
        esperando = false;
        estadoActual = siguiente;
        tiempo = 0f;
        desplazamientoAleatorio = Random.Range(0f, 100f);
    }
}
