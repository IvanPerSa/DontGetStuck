using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public float throwForce = 10f; // Fuerza del lanzamiento
    private Rigidbody2D rb;
    private Collider2D col;
    private bool isBeingHeld = false;
    private Transform player;
    public GameObject playerController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isBeingHeld)
        {
            transform.position = player.position + new Vector3(player.localScale.x * 1.2f, 0.5f, 0);

            // Lanzar el objeto
            if (Input.GetKeyDown(KeyCode.E))
            {
                Throw();
            }
        }
    }

    public void PickUp(Transform playerTransform, PlayerController controller)
    {
        isBeingHeld = true;
        player = playerTransform;
       // playerController = controller;
        rb.isKinematic = true;  // Evita que la física lo mueva
        col.enabled = false; // Evita colisiones mientras es sostenido
    }

    public void Throw()
    {
        isBeingHeld = false;
        rb.isKinematic = false;
        col.enabled = true;

        // Aplicar fuerza en la dirección en que mira el jugador
        rb.velocity = new Vector2(player.localScale.x * throwForce, 5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con el suelo, puedes agregar efectos, sonidos o rebotes
        if (collision.gameObject.CompareTag("ground"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y * 0.5f); // Rebote reducido
        }
    }
}
