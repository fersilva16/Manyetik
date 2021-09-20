using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
  private CheckpointManger cm;

  private void Start()
  {
    cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointManger>();
  }

  private void OnTriggerEnter2D(Collider2D col)
  {
    if(col.CompareTag("Player"))
    {
        cm.lastCheckpointpos = transform.position;
    }
  }
}
