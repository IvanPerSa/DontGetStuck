using UnityEngine;

public class FullScreenBackground : MonoBehaviour
{
    void Start()
    {
        // Obtén el componente SpriteRenderer para acceder al tamaño del sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on this GameObject.");
            return;
        }

        // Obtén las dimensiones del sprite
        float spriteWidth = spriteRenderer.bounds.size.x;
        float spriteHeight = spriteRenderer.bounds.size.y;

        // Calcula la altura y el ancho del mundo visible
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;

        // Ajustar el tamaño del fondo para cubrir toda la pantalla
        Vector3 scale = transform.localScale;
        scale.x = worldWidth / spriteWidth; // Ajusta el ancho
        scale.y = worldHeight / spriteHeight; // Ajusta la altura
        transform.localScale = scale;
    }
}
