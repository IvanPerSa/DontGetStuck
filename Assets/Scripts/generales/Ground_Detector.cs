using UnityEngine;

public class Ground_Detector : MonoBehaviour
{
    //public GameObject player;
    public MovimientoPersonaje movimientoPersonaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Suelos" || collision.gameObject.tag == "Interactuable")
            movimientoPersonaje.setGround(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Suelos" || collision.gameObject.tag == "Interactuable")
            movimientoPersonaje.setGround(!true);
    }
}
