using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public int jumpCount = 1;

    private Rigidbody2D rb;
    private float moveDir;
    private bool jump;
    private int jumpsLeft;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * moveDir * Time.deltaTime, rb.velocity.y);

        if (jump && jumpsLeft>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            jump = false;
            jumpsLeft -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpsLeft = jumpCount;
    }
}
