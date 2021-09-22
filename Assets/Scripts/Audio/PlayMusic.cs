using UnityEngine;

public class PlayMusic : MonoBehaviour
{
  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip[] musics;

  private void Start()
  {
    audioSource = GetComponent<AudioSource>();

    audioSource.clip = musics[Random.Range(0, musics.Length - 1)];
    audioSource.PlayOneShot(audioSource.clip);
  }
}
