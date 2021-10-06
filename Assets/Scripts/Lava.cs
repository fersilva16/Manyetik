using System;
using UnityEngine;

public class Lava : MonoBehaviour
{
  public static event Action Collided;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !other.isTrigger) Collided?.Invoke();
  }
}
