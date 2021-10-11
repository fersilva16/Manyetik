using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoinEdges : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D other)
  {
    if(other.gameObject.CompareTag("Coin"))
    {
      Destroy(other.gameObject, 1f);
    }
  }
}
