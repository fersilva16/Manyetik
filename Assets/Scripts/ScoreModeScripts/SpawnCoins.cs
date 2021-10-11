using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCoins : MonoBehaviour
{
  [SerializeField]
  private Transform spawnPoint;

  [SerializeField]
  private float spawnTime;

  [SerializeField]
  private float delayTime;

  [SerializeField]
  private GameObject coin;

  private void OnEnable() => InputManager.Interact += OnSpawnInput;
  private void OnDisable() => InputManager.Interact -= OnSpawnInput;

  private void OnSpawnInput(InputAction.CallbackContext context)
  {
    InvokeRepeating("SpawnObject", spawnTime, delayTime);
  }

  public void SpawnObject()
  {
    Instantiate(coin, spawnPoint.position, spawnPoint.rotation);
  }
}
