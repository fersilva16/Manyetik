using System;
using UnityEngine;

public class Lava : MonoBehaviour
{
  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip audioClip;

  public static event Action Collided;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !other.isTrigger)
    {
      Collided?.Invoke();
      audioSource.PlayOneShot(audioClip);
    }
  }
}
