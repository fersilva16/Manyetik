using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
   public float speed;
    public float jumpForce;
    public bool isJumping;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal2"), 0f, 0f);
        transform.position += move * Time.deltaTime * speed;
    }
    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

}