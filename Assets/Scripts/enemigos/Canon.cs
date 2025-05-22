using System.Collections;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject CanonShot;
    public Transform canonShotAngle;
    public float tiempoEntreDisparos = 0.2f;
    public int disparosPorVuelta = 3;

    private Animator animator;
    private string nombreAnimacionDisparo = "CañonDisparar";

    private bool disparando = false;
    private bool esperandoCoroutine = false;

    private string animacionAnterior = "";

    void Start()
    {
        animator = GetComponent<Animator>();
        animacionAnterior = "";
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        string animacionActual = stateInfo.IsName(nombreAnimacionDisparo) ? nombreAnimacionDisparo : "Otra";

        // Detectar cuando la animación entra a "CañonDisparar"
        if (animacionActual == nombreAnimacionDisparo && animacionAnterior != nombreAnimacionDisparo)
        {
            if (!esperandoCoroutine)
            {
                StartCoroutine(DispararMultiple());
            }
        }

        animacionAnterior = animacionActual;
    }

    private IEnumerator DispararMultiple()
    {
        esperandoCoroutine = true;

        for (int i = 0; i < disparosPorVuelta; i++)
        {
            Instantiate(CanonShot, canonShotAngle.position, canonShotAngle.rotation);
            yield return new WaitForSeconds(tiempoEntreDisparos);
        }

        esperandoCoroutine = false;
    }
}
