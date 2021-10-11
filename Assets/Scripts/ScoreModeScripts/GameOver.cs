using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
  [SerializeField]
  private Animator animator;

  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Coin"))
    {
      Destroy(other.gameObject);

      Time.timeScale = 0f;

      animator.Play("Open");
    }
  }
}
