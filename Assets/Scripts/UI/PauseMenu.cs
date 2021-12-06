using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : Menu
{
  private void OnEnable() => InputManager.Menu += OnMenuInput;
  private void OnDisable() => InputManager.Menu -= OnMenuInput;

  private void OnMenuInput(InputAction.CallbackContext _)
  {
    if (Time.timeScale == 0f) Resume();
    else Paused();
  }

  public void Resume()
  {
    Close();
    Time.timeScale = 1f;
  }

  public void Paused()
  {
    Open();
    Time.timeScale = 0f;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Menu");
  }
}
