using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public Transform target; // El objetivo (personaje) que la cámara sigue
    public Vector2 minBounds; // Límites mínimos (izquierda, abajo)
    public Vector2 maxBounds; // Límites máximos (derecha, arriba)
    public float smoothSpeed = 0.125f; // Velocidad de suavizado de la cámara
    public Vector3 offset; // Desplazamiento de la cámara respecto al objetivo

    void LateUpdate()
    {
        // Verifica que el objetivo (target) esté asignado
        if (target == null) return;

        // Calcula la posición deseada de la cámara (con el offset)
        Vector3 desiredPosition = target.position + offset;

        // Aplica los límites a la posición de la cámara
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // Calcula la nueva posición de la cámara con los límites aplicados
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Suaviza el movimiento de la cámara para un movimiento más fluido
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
    }
}
