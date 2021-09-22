using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
  public static event Action<Vector3> OnTrigger;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Player")) OnTrigger?.Invoke(transform.position);
  }
}
