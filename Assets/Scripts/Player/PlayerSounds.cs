using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip[] soundsPlayer;

  private void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  public void Footstep()
  {
    audioSource.clip = soundsPlayer[Random.Range(0,soundsPlayer.Length)];
    audioSource.PlayOneShot(audioSource.clip);
  }
}
