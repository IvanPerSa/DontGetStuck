using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    // Referencia al Canvas que quieres mostrar/ocultar
    public GameObject MenuEsc;

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que el menú esté inicialmente oculto
      
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar si se presiona la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambiar el estado de activación del Canvas (si está activo lo desactiva y viceversa)
            MenuEsc.SetActive(!MenuEsc.activeSelf);


        }
    }
}
