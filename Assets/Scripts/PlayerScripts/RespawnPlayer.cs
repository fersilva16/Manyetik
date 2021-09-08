using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
  public static RespawnPlayer instance;

  public Transform respawnPoint;
  public GameObject playerPrefab;

  public void Awake()
  {
    instance = this;
  }

  public void Respawn()
  {
    Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
  }
}
