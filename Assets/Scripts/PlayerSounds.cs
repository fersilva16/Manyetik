using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
  public AudioSource audioSource;

  public AudioClip[] footsteps;

  public void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }
  public void Footstep()
  {
    audioSource.clip = footsteps[Random.Range(0,footsteps.Length)];
    audioSource.PlayOneShot(audioSource.clip);
  }
}
