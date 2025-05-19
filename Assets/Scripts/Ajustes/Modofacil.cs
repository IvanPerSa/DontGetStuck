using UnityEngine;
using UnityEngine.UI;

public class ModoFacilToggle : MonoBehaviour
{
    public Toggle modoFacilToggle;            // Referencia al Toggle en el Canvas
    public GameObject checkpointHandler;      // (Opcional) Objeto que gestiona checkpoints u otra lógica

    void Awake()
    {
        // Cargar el estado guardado del modo fácil (0 = desactivado, 1 = activado)
        bool modoFacilGuardado = PlayerPrefs.GetInt("ModoFacil", 0) == 1;

        // Forzar que el toggle refleje el estado guardado
        modoFacilToggle.isOn = modoFacilGuardado;

        // Activar o desactivar el objeto que controla los checkpoints según el modo fácil
        if (checkpointHandler != null)
            checkpointHandler.SetActive(modoFacilGuardado);
    }

    void Start()
    {
        // Agregar listener para detectar cambios en el toggle
        modoFacilToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        // Guardar el nuevo estado en PlayerPrefs
        PlayerPrefs.SetInt("ModoFacil", isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Activar o desactivar el objeto asociado
        if (checkpointHandler != null)
            checkpointHandler.SetActive(isOn);
    }
}
