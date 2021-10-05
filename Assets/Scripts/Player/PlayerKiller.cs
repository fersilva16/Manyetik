using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
  private Vector3 respawnPoint;

  private void OnEnable()
  {
    CheckpointController.Reached += OnCheckpointReached;
  }

  private void OnDisable()
  {
    CheckpointController.Reached -= OnCheckpointReached;
  }

  private void Start()
  {
    respawnPoint = transform.position;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Lava")) transform.position = respawnPoint;
  }

  private void OnCheckpointReached(Vector3 position)
  {
    respawnPoint = position;
  }
}
