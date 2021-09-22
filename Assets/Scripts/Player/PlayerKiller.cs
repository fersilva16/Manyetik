using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
  [SerializeField]
  [Layer]
  private int lavaLayer;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.layer == lavaLayer && CheckpointManager.instance)
    {
      transform.position = CheckpointManager.instance.lastCheckpointPosition;
    }
  }
}
