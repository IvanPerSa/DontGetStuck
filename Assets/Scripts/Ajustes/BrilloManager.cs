using UnityEngine;

public class BrilloManager : MonoBehaviour
{
    public static BrilloManager instancia;
    private float brilloActual = 0.5f;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBrillo(float valor)
    {
        brilloActual = valor;
        PlayerPrefs.SetFloat("brillo", brilloActual);
        PlayerPrefs.Save();
    }

    public float GetBrillo()
    {
        return PlayerPrefs.GetFloat("brillo", 0.5f);
    }
}
