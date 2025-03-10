using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzableColisiones : MonoBehaviour
{
    public LayerMask whatIsWall;
    public float wallCheckRadius = 0.2f;
    [SerializeField] private Transform wallCheck;
    public bool isTouchingWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.root.gameObject.name == "ControladorColisiones")
        {
            isTouchingWall = true;  
            //isGrounded = true;
            //jumpsLeft = maxJumps; // Resetea el doble salto
            //isDoubleJumping = false; // Resetear el estado del doble salto al tocar el suelo
        }
    }
}
