using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
  private Vector3 respawnPoint;

  private void OnEnable()
  {
    Checkpoint.Reached += OnCheckpointReached;
    Lava.Collided += OnLavaCollided;
  }

  private void OnDisable()
  {
    Checkpoint.Reached -= OnCheckpointReached;
    Lava.Collided -= OnLavaCollided;
  }

  private void Start()
  {
    respawnPoint = transform.position;
  }

  private void OnCheckpointReached(Vector3 position)
  {
    respawnPoint = position;
  }

  private void OnLavaCollided()
  {
    transform.position = respawnPoint;
  }
}
