using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
  public AudioSource audioSource;

  public AudioClip fire;

  public void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }
}
