using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Movement Player;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<Movement>();
    }
    // Metodos que checam se o player ta ou n encostando no chao pra impedir q ele pule infinitamente
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 8)
        {
            Player.isJumping = false;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.layer == 8)
        {
            Player.isJumping = true;
        }
    }
}
