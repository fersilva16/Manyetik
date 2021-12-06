using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NextLevel : MonoBehaviour
{
  [SerializeField]
  [Scene]
  private string scene;

  [SerializeField]
  private Animator animationDoor;

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
    GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("Player");

    foreach(GameObject go in gameObjectArray)
    {
      go.SetActive (false);
    }
  }
}
