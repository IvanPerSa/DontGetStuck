using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El personaje o el objeto que la cámara seguirá
    public float offsetY = 1f; // Distancia vertical (ajustar según necesites)
    public float offsetZ = -10f; // Distancia en el eje Z, normalmente es negativo para que la cámara esté detrás del personaje

    private void LateUpdate()
    {
        // Posición de la cámara: seguir al personaje en X y Z, pero mantener un offset en Y y Z
        transform.position = new Vector3(target.position.x, target.position.y + offsetY, offsetZ);
    }
}
