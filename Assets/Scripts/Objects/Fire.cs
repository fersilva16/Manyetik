using System;
using UnityEngine;

public class Fire : MonoBehaviour
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
      var magnetism = other.GetComponent<PlayerMagnetism>();

      if (magnetism.IsMagnetized()) audioSource.PlayOneShot(audioClip);

      Collided?.Invoke();
    }
  }
}
