using UnityEngine;

public class ParallaxBg : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backspeed;

    float farthestBack;

    [Range(0.01f, 0.2f)]
    public float parallaxSpeed = 0.05f;

    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        backgrounds = new GameObject[backCount];
        mat = new Material[backCount];
        backspeed = new float[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        farthestBack = float.MinValue;

        for (int i = 0; i < backCount; i++)
        {
            float zDistance = backgrounds[i].transform.position.z - cam.position.z;

            if (zDistance > farthestBack)
            {
                farthestBack = zDistance;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            float zDistance = backgrounds[i].transform.position.z - cam.position.z;
            backspeed[i] = 1 - (zDistance / farthestBack);
            backspeed[i] = Mathf.Clamp(backspeed[i], 0.1f, 1f);
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;

        // 🔥 Mantener el fondo alineado con la cámara en X, pero NO en Y
        transform.position = new Vector3(cam.position.x, camStartPos.y, transform.position.z);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backspeed[i] * parallaxSpeed * 2f;
            Vector2 offset = mat[i].GetTextureOffset("_MainTex");
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance * speed, offset.y));

            // 🔥 Asegurar que el fondo no se quede demasiado atrás
            if (backgrounds[i].transform.position.x < cam.position.x - 10f)
            {
                backgrounds[i].transform.position = new Vector3(cam.position.x, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
            }
        }
    }

}
