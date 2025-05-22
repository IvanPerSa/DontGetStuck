using UnityEngine;

public class CanonShotMover : MonoBehaviour
{
    public float velocidad = 10f;
    public float duracion = 2.5f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Mueve el proyectil hacia la derecha seg�n la rotaci�n del transform
        // En 2D, usualmente se usa Vector2.right * velocidad, ajustado por la rotaci�n Z

        // Calculamos la direcci�n en 2D seg�n la rotaci�n Z
        float anguloRad = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direccion = new Vector2(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad));

        rb2d.linearVelocity = direccion * velocidad;

        Destroy(gameObject, duracion);
    }
}
