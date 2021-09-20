using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManger : MonoBehaviour
{
  private static CheckpointManger instance;
  public Vector2 lastCheckpointpos;

  private void Awake()
  {
    if(instance == null)
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }
    else
    {
        Destroy(gameObject);
    }
  }
}
