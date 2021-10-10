using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCoins : MonoBehaviour
{
  [SerializeField]
  private Transform spawnPoint;

  [SerializeField]
  private float respawnTime = 2f;

  [SerializeField]
  private GameObject coin;

  private void OnEnable() => InputManager.Interact += OnSpawnInput;
  private void OnDisable() => InputManager.Interact -= OnSpawnInput;

  private void OnSpawnInput(InputAction.CallbackContext context)
  {
    StartCoroutine(MultipleSpawn());
  }

  public void Spawn()
  {
    Instantiate(coin, spawnPoint.position, spawnPoint.rotation);
  }

  IEnumerator MultipleSpawn()
  {
    while(true)
    {
      yield return new WaitForSeconds (respawnTime);
      Spawn();
    }
  }
}
