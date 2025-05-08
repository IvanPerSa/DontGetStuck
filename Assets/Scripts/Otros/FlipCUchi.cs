using UnityEngine;

public class SeguimientoPrinci : MonoBehaviour
{
    private Transform Princi;  // Referencia al transform de Princi
    private SpriteRenderer spritePrinci;  // Referencia al SpriteRenderer de Princi
    private SpriteRenderer spriteMinicuchi;  // Referencia al SpriteRenderer de Minicuchi

    public Vector3 offset;  // El offset para posicionar Minicuchi correctamente respecto a Princi

    private float posPrinciAnteriorX;

    void Start()
    {
        // Obtener referencias a los componentes
        Princi = GameObject.FindGameObjectWithTag("PersonajePrincipal").transform;  // Buscar Princi por el tag
        spritePrinci = Princi.GetComponent<SpriteRenderer>();  // Obtener SpriteRenderer de Princi
        spriteMinicuchi = GetComponent<SpriteRenderer>();  // Obtener SpriteRenderer de Minicuchi

        posPrinciAnteriorX = Princi.position.x;  // Guardamos la posición inicial en X de Princi
    }

    void Update()
    {
        if (Princi != null && spritePrinci != null && spriteMinicuchi != null)
        {
            // Verificar si la posición en el eje X de Princi ha cambiado de dirección
            if (Princi.position.x > posPrinciAnteriorX)
            {
                // Princi se mueve hacia la derecha
                if (spriteMinicuchi.flipY) // Si ya está flipado, deshacerlo
                {
                    spriteMinicuchi.flipY = false;  // Minicuchi se voltea de nuevo
                }
            }
            else if (Princi.position.x < posPrinciAnteriorX)
            {
                // Princi se mueve hacia la izquierda
                if (!spriteMinicuchi.flipY) // Si no está flipado, hacerlo
                {
                    spriteMinicuchi.flipY = true;  // Minicuchi se voltea
                }
            }

            // Actualizamos la posición de Minicuchi con el offset
            float offsetX = Princi.localScale.x > 0 ? Mathf.Abs(offset.x) : -Mathf.Abs(offset.x);
            transform.position = Princi.position + new Vector3(offsetX, offset.y, offset.z);

            // Guardamos la posición actual de Princi para la siguiente comparación
            posPrinciAnteriorX = Princi.position.x;
        }
    }
}

