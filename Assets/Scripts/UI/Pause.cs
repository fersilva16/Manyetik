using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
  public static bool GameisPaused = false;

  [SerializeField]
  private GameObject pauseMenu;

  [SerializeField]
  private Animator animationPM;

  private void OnEnable() => InputManager.Menu += OnMenuInput;
  private void OnDisable() => InputManager.Menu -= OnMenuInput;

  private void OnMenuInput(InputAction.CallbackContext _)
  {
    if (GameisPaused) Resume();
    else Paused();
  }

  public void Resume()
  {
    animationPM.Play("PauseMenu_2");
    Time.timeScale = 1f;
    GameisPaused = false;
  }

  public void Paused()
  {
    animationPM.Play("PauseMenu");
    Time.timeScale = 0f;
    GameisPaused = true;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Menu");
  }

}
