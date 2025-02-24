using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El personaje o el objeto que la c�mara seguir�
    public float offsetY = 1f; // Distancia vertical (ajustar seg�n necesites)
    public float offsetZ = -10f; // Distancia en el eje Z, normalmente es negativo para que la c�mara est� detr�s del personaje

    private void LateUpdate()
    {
        // Posici�n de la c�mara: seguir al personaje en X y Z, pero mantener un offset en Y y Z
        transform.position = new Vector3(target.position.x, target.position.y + offsetY, offsetZ);
    }
}
