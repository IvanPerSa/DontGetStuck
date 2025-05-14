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

    private enum Estado
    {
        Bajando, EsperandoAntesIzquierda,
        Izquierda, EsperandoAntesDerecha,
        Derecha, EsperandoAntesSubida,
        Subiendo, EsperandoAntesBajar
    }

    private Estado estadoActual = Estado.Bajando;

    private float tiempo = 0f;
    private float xInicio;
    private float desplazamientoAleatorio;
    private bool enPausa = false;
    private bool activo = false;

    void Start()
    {
        xInicio = transform.position.x;
        desplazamientoAleatorio = Random.Range(0f, 100f);
    }

    void Update()
    {
        if (!activo || enPausa) return;

        Vector3 pos = transform.position;
        float delta = velocidad * Time.deltaTime;

        switch (estadoActual)
        {
            case Estado.Bajando:
                pos.y = Mathf.MoveTowards(pos.y, alturaMin, delta);
                tiempo += Time.deltaTime;
                pos.x = xInicio + Mathf.Sin(tiempo * frecuenciaLateral) * amplitudLateral;

                if (Mathf.Abs(pos.y - alturaMin) < 0.01f)
                {
                    StartCoroutine(PausarAntesDe(Estado.Izquierda));
                    estadoActual = Estado.EsperandoAntesIzquierda;
                }
                break;

            case Estado.Izquierda:
                pos.x = Mathf.MoveTowards(pos.x, destinoIzquierdaX, delta);
                tiempo += Time.deltaTime;
                pos.y = alturaMin + Mathf.Sin((tiempo + desplazamientoAleatorio) * frecuenciaVerticalZigZag) * amplitudVerticalZigZag;

                if (Mathf.Abs(pos.x - destinoIzquierdaX) < 0.01f)
                {
                    StartCoroutine(PausarAntesDe(Estado.Derecha));
                    estadoActual = Estado.EsperandoAntesDerecha;
                }
                break;

            case Estado.Derecha:
                pos.x = Mathf.MoveTowards(pos.x, xInicio, delta);
                tiempo += Time.deltaTime;
                pos.y = alturaMin + Mathf.Sin((tiempo + desplazamientoAleatorio) * frecuenciaVerticalZigZag) * amplitudVerticalZigZag;

                if (Mathf.Abs(pos.x - xInicio) < 0.01f)
                {
                    StartCoroutine(PausarAntesDe(Estado.Subiendo));
                    estadoActual = Estado.EsperandoAntesSubida;
                }
                break;

            case Estado.Subiendo:
                pos.y = Mathf.MoveTowards(pos.y, alturaMax, delta);
                tiempo += Time.deltaTime;
                pos.x = xInicio + Mathf.Sin(tiempo * frecuenciaLateral) * amplitudLateral;

                if (Mathf.Abs(pos.y - alturaMax) < 0.01f)
                {
                    StartCoroutine(PausarAntesDe(Estado.Bajando));
                    estadoActual = Estado.EsperandoAntesBajar;
                }
                break;
        }

        transform.position = pos;
    }

    IEnumerator PausarAntesDe(Estado siguienteEstado)
    {
        enPausa = true;
        Vector3 posicionCongelada = transform.position;

        float duracionEspera = 0.5f;
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionEspera)
        {
            transform.position = posicionCongelada;
            tiempoPasado += Time.deltaTime;
            yield return null;
        }

        tiempo = 0f;
        desplazamientoAleatorio = Random.Range(0f, 100f);
        estadoActual = siguienteEstado;
        enPausa = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!activo && collision.gameObject.CompareTag("PersonajePrincipal"))
        {
            activo = true;
        }
    }
}
