using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
  public static CheckpointManager instance { get; private set; }

  public Vector2 lastCheckpointPosition { get; private set; }

  private void Awake()
  {
    if (instance != null) Destroy(gameObject);
    else
    {
      instance = this;
      DontDestroyOnLoad(instance);
    }
  }

  private void OnEnable()
  {
    Checkpoint.OnTrigger += SaveCheckpoint;
  }

  private void OnDisable()
  {
    Checkpoint.OnTrigger -= SaveCheckpoint;
  }

  private void SaveCheckpoint(Vector3 position)
  {
    lastCheckpointPosition = position;
  }
}
