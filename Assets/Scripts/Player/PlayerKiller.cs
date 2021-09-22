using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiller : MonoBehaviour
{
  [SerializeField]
  [Layer]
  private int killableLayer;

  private void Start()
  {
    if (CheckpointManager.instance)
    {
      transform.position = CheckpointManager.instance.lastCheckpointPosition;
    }
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.layer == killableLayer)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}
