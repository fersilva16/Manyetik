using UnityEngine;

public class InteractIcon : MonoBehaviour
{
  [SerializeField]
  private GameObject icon;

  [SerializeField]
  private bool show = true;

  private bool playerInRange;

  private void Update()
  {
    if (show && playerInRange) icon.SetActive(true);
    else icon.SetActive(false);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !other.isTrigger) playerInRange = true;
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !other.isTrigger) playerInRange = false;
  }
}
