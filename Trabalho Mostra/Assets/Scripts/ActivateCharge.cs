using UnityEngine;

public class ActivateCharge : MonoBehaviour
{
  [SerializeField] GameObject charge;

  void Start()
  {
    charge.SetActive(false);
  }

  void OnCollisionEnter2D(Collision2D col) 
  {
    if (col.gameObject.CompareTag("Player")) charge.SetActive(true);
  }
}
