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

  [SerializeField]
  private Animator animationDoor;

  [SerializeField]
  private GameObject player;

  private void OnEnable() => InputManager.Interact += OnInteractInput;
  private void OnDisable() => InputManager.Interact -= OnInteractInput;

  private void Start()
  {
    player.SetActive(true);
  }

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
    if (playerInRange)
    {
      animationDoor.Play("Close");
    }
  }

  public void LoadScene()
  {
    SceneManager.LoadScene(scene);
  }

  public void DisactivePlayer()
  {
    player.SetActive(false);
  }
}
