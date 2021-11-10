using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : Menu
{
  public static bool GameisPaused = false;

  private void OnEnable() => InputManager.Menu += OnMenuInput;
  private void OnDisable() => InputManager.Menu -= OnMenuInput;

  private void OnMenuInput(InputAction.CallbackContext _)
  {
    if (GameisPaused) Resume();
    else Paused();
  }

  public void Resume()
  {
    Close();
    Time.timeScale = 1f;
    GameisPaused = false;
  }

  public void Paused()
  {
    Open();
    Time.timeScale = 0f;
    GameisPaused = true;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Menu");
  }
}
