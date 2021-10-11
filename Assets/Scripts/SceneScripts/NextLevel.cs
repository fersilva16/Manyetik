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

  private void OnEnable() => InputManager.Interact += OnInteractInput;
  private void OnDisable() => InputManager.Interact -= OnInteractInput;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player")) playerInRange = true;
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player")) playerInRange = false;
  }

  private void OnInteractInput(InputAction.CallbackContext context)
  {
    if (!playerInRange) return;

    SceneManager.LoadScene(scene);
  }
}
