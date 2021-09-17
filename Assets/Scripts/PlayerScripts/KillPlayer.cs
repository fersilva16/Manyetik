using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
  public void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.layer == 10)
    {
      Destroy(gameObject);
      RespawnPlayer.instance.Respawn();
    }
  }
}
