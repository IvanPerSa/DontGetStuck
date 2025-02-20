using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public Transform target; // El objetivo (personaje) que la c�mara sigue
    public Vector2 minBounds; // L�mites m�nimos (izquierda, abajo)
    public Vector2 maxBounds; // L�mites m�ximos (derecha, arriba)
    public float smoothSpeed = 0.125f; // Velocidad de suavizado de la c�mara
    public Vector3 offset; // Desplazamiento de la c�mara respecto al objetivo

    void LateUpdate()
    {
        // Verifica que el objetivo (target) est� asignado
        if (target == null) return;

        // Calcula la posici�n deseada de la c�mara (con el offset)
        Vector3 desiredPosition = target.position + offset;

        // Aplica los l�mites a la posici�n de la c�mara
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // Calcula la nueva posici�n de la c�mara con los l�mites aplicados
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Suaviza el movimiento de la c�mara para un movimiento m�s fluido
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
    }
}
