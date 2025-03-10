using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lanzable_Item : MonoBehaviour
{
    private bool puedeRecoger;
    private bool objetoEnMano;
    public Transform personajePirncipal;
    public Rigidbody2D rbObjeto;
    public Collider2D colliderObjeto;
  
    // Start is called before the first frame update
    void Start()
    {
        personajePirncipal = GameObject.FindWithTag("PersonajePrincipal").transform;
        puedeRecoger = false;
        objetoEnMano = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E) && !objetoEnMano && puedeRecoger)
        {
            LevantarObjetoConMano();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PersonajePrincipal")
        {
            puedeRecoger = true;
        }
    }

    void LevantarObjetoConMano()
    {
        // Ponemos el objeto en la mano del jugador (como hijo del jugador)
        this.transform.SetParent(personajePirncipal);

        // Lo posicionamos justo frente al personaje (dependiendo de la dirección)
    

        // Desactivamos la física para que el objeto no se vea afectado por la gravedad
        rbObjeto.isKinematic = true;

        // Desactivamos las colisiones entre el personaje y la caja
        Physics2D.IgnoreCollision(colliderObjeto, personajePirncipal.GetComponent<Collider2D>(), true);

        // Hacemos que la caja no colisione con otros objetos durante el levantamiento
        //colliderObjeto.isTrigger = true; // Activa el Trigger para que no interfiera con colisiones

        objetoEnMano = true;
    }
}
