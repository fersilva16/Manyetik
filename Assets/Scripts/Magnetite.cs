using System;
using UnityEngine;

public class Magnetite : MonoBehaviour
{
  public static event Action Collided;

  private void OnCollisionEnter2D(Collision2D other)
  {
     if (other.gameObject.CompareTag("Player")) Collided?.Invoke();
  }
}
