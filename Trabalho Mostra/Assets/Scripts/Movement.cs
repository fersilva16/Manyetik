using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public bool isJumping;
    private Rigidbody2D rb;
    
    // O Metodo Start e chamado ao iniciar a cena
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // O metodo Update e chamado a cada frame
    void Update()
    {
        Move();
        Jump();
    }
    // Metodo que premite movimentar um objeto na horizontal usando (por configuaraçao propria da unity) as teclas A, D, LeftArrow, RightArrow
    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }
    // Metodo que faz o objeto pular qnd precionada o tecla W mas da pra mudar pra outras teclas
    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W) &&!isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
