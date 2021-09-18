using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
  private CheckpointManger cm;

  void Start()
  {
    cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointManger>();
    transform.position = cm.lastCheckpointpos;
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.layer == 10)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}
