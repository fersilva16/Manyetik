using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip audioClip;

  public void ClickSound()
  {
    audioSource.PlayOneShot(audioClip);
  }
}
