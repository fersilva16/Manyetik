using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
  [SerializeField]
  private bool checkpointReached;

  [SerializeField]
  private Animator animationCheckpoint;

  private void Update()
  {
    if(checkpointReached)
    {
      animationCheckpoint.SetTrigger("Reached");
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player") checkpointReached = true;
  }
}
