using System;
using UnityEngine;

public class Basket : MonoBehaviour
{
  public static event Action CoinDunk;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Coin"))
    {
      Destroy(other.gameObject);

      CoinDunk?.Invoke();
    }
  }
}
