using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NextLevel : MonoBehaviour
{
  [SerializeField]
  [Scene]
  private string scene;

  [SerializeField]
  private bool playerInRange;

  public void OnNextLevelInput(InputAction.CallbackContext context)
  {
    if (!playerInRange) return;

    SceneManager.LoadScene(scene);
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Player")) playerInRange = true;
  }

  private void OnTriggerExit2D(Collider2D collider)
  {
    playerInRange = false;
  }
}
