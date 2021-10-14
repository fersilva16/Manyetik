using System;
using UnityEngine;

public class Basket : MonoBehaviour
{
  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip audioClip;
  public static event Action CoinDunk;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Coin"))
    {
      Destroy(other.gameObject);

      audioSource.PlayOneShot(audioClip);

      CoinDunk?.Invoke();
    }
  }
}
