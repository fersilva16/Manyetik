using System;
using UnityEngine;

public class Magnetite : MonoBehaviour
{
  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip audioClip;

  public static event Action Collided;

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      Collided?.Invoke();

      var magnetism = other.gameObject.GetComponent<PlayerMagnetism>();

      if (!magnetism.IsMagnetized()) audioSource.PlayOneShot(audioClip);
    }
  }
}
