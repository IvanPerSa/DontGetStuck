using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public float floatHeight = 0.5f;  // Altura máxima del movimiento
    public float floatSpeed = 1f;     // Velocidad del movimiento

    private Vector3 startPos;         // Posición inicial del objeto

    void Start()
    {
        // Guardar la posición inicial del objeto
        startPos = transform.position;
    }

    void Update()
    {
        // Movimiento suave de arriba a abajo usando Mathf.PingPong
        float newY = Mathf.PingPong(Time.time * floatSpeed, floatHeight * 2) - floatHeight;

        // Actualizamos la posición del objeto, solo modificando el eje Y
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}
