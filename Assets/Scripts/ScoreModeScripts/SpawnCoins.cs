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

  private void OnEnable() => InputManager.Interact += OnInteractInput;
  private void OnDisable() => InputManager.Interact -= OnInteractInput;

  private void OnInteractInput(InputAction.CallbackContext context)
  {
    InvokeRepeating("SpawnObject", spawnTime, delayTime);
  }

  public void SpawnObject()
  {
    Instantiate(coin, spawnPoint.position, spawnPoint.rotation);
  }
}
