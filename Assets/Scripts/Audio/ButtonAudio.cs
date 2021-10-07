using UnityEngine;

public class ButtonAudio : MonoBehaviour
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
