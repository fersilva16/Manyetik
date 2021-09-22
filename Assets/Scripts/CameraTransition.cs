using UnityEngine;

public class CameraTransition : MonoBehaviour
{
  [SerializeField]
  private GameObject virtualCam;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Player")) virtualCam.SetActive(true);
  }

  public void OnTriggerExit2D(Collider2D collider)
  {
    if (collider.CompareTag("Player")) virtualCam.SetActive(false);
  }
}
