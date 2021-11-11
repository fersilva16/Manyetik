using UnityEngine;
using NaughtyAttributes;

public class SpawnCoins : MonoBehaviour
{
  [SerializeField]
  private Transform spawnPoint;

  [SerializeField]
  private float spawnTime;

  [SerializeField]
  private float delayTime;

  [SerializeField]
  private GameObject coinPrefab;

  [SerializeField]
  [MinMaxSlider(-100, 100)]
  private Vector2 rotationRange;

  private void Start()
  {
    InvokeRepeating("SpawnObject", spawnTime, delayTime);
  }

  public void SpawnObject()
  {
    var coin = Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation);
    var rigidBody2D = coin.GetComponent<Rigidbody2D>();

    rigidBody2D.angularVelocity = Random.Range(rotationRange.x, rotationRange.y);
  }
}
