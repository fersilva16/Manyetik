using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoins : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D col)
  {
    Destroy(GameObject.Find("Coin(Clone)"));
  }
}
