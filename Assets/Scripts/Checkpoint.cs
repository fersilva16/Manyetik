using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
  public static event Action<Vector3> Reached;

  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip audioClip;

  private Animator animator;

  private bool reached;

  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!reached && other.CompareTag("Player") && !other.isTrigger)
    {
      reached = true;

      animator.SetTrigger("Reached");

      audioSource.PlayOneShot(audioClip);

      Reached?.Invoke(transform.position);
    }
  }
}
