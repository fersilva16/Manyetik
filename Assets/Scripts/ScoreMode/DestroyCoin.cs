using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Coin"))
    {
      Destroy(other.gameObject);
    }
  }
}
