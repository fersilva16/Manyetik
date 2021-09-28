using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
  public Vector3 respawnPoint;

  private void Start()
  {
    respawnPoint = transform.position;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Lava")) transform.position = respawnPoint;

    if (other.CompareTag("Checkpoint")) respawnPoint = other.transform.position;
  }
}
