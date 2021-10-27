using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBox : MonoBehaviour
{
  public Vector3 respawnPoint;

  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip audioClip;

  private void Start()
  {
    respawnPoint= transform.position;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Lava" || other.tag == "Fire")
    {
      transform.position = respawnPoint;
      audioSource.PlayOneShot(audioClip);
    }
  }
}
