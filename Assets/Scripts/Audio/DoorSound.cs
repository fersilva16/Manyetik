using UnityEngine;

public class DoorSound : MonoBehaviour
{
    [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip audioClip;

  public void DoorClose()
  {
    audioSource.PlayOneShot(audioClip);
  }
}
