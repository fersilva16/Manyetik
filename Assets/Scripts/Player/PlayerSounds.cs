using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
  public AudioSource audioSource;

  public AudioClip[] soundsPlayer;

  public void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }
  
  public void Footstep()
  {
    audioSource.clip = soundsPlayer[Random.Range(0,soundsPlayer.Length)];
    audioSource.PlayOneShot(audioSource.clip);
  }
}
