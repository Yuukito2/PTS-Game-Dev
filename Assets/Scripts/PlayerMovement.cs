using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float jumpPower = 3.5f;
    public bool canJump;
    public Rigidbody rb;

    void Start()
    {
        canJump = true;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        //Player Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal != 0 || vertical != 0 )
        {
            Vector3 move = new Vector3(horizontal * playerSpeed * Time.deltaTime, 0, vertical * playerSpeed * Time.deltaTime);
            transform.Translate(move);
        }

        //Player Jump
        if ( Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0, jumpPower * 10, 0));
            canJump = false;
        }
    }

    //Check if Player is on top of Ground
    void OnCollisionEnter( Collision collision )
    {
        if(collision.transform.tag == "Ground" )
        {
            canJump = true;
        }
    }
}
