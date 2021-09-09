using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
  public AudioSource audioSource;

  public AudioClip[] fire;

  public void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }
  public void Flametrower()
  {
    audioSource.clip = fire[0];
    audioSource.PlayOneShot(audioSource.clip);
  }

  public void StartFire()
  {
    audioSource.clip = fire[1];
    audioSource.PlayOneShot(audioSource.clip);
  }

  public void StopSound()
  {
    audioSource.Stop();
  }
}
