using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
  public static bool GameisPaused = false;

  private Animator animator;

  private void OnEnable() => InputManager.Menu += OnMenuInput;
  private void OnDisable() => InputManager.Menu -= OnMenuInput;

  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  private void OnMenuInput(InputAction.CallbackContext _)
  {
    if (GameisPaused) Resume();
    else Paused();
  }

  public void Resume()
  {
    animator.Play("Close");
    Time.timeScale = 1f;
    GameisPaused = false;
  }

  public void Paused()
  {
    animator.Play("Open");
    Time.timeScale = 0f;
    GameisPaused = true;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Menu");
  }

}
