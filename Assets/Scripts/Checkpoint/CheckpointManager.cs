using System.Collections;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
  public bool checkpointReached;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player") checkpointReached = true;
  }
}
