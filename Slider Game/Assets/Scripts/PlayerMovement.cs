using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 1000f;

    public float initialJumpForce = 3f;
    public float airJumpForce = 5f;
    public float jumpTime = 1f;
    private float jumpTimeCounter = 0f;

    private float movingX;
    private Vector3 clampedPos;

    private bool isGrounded;
    private bool jumping;
    public bool continiousJump;

    

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.name == "Ground")
        {
            isGrounded = true;
        }
    }

    private void Update()
    {
        movingX = Input.GetAxisRaw("Horizontal");
        jumping = Input.GetButton("Jump");
        if (Input.GetButtonUp("Jump"))
        {
            continiousJump = false;
        }


    }
    
    

    void FixedUpdate()
    {
        rb.AddForce(movingX * moveSpeed * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);

        clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -4.5f, 4.5f);
        transform.position = clampedPos;

        if (jumping && isGrounded)
        {
            rb.AddForce(Vector3.up * initialJumpForce, ForceMode.Impulse);
            isGrounded = false;
            continiousJump = true;
            jumpTimeCounter = 0;
        }

        if(jumping && jumpTimeCounter < jumpTime && continiousJump)
        {
            rb.AddForce(Vector3.up * airJumpForce, ForceMode.Force);
            jumpTimeCounter += Time.fixedDeltaTime;
        }
    }
}
