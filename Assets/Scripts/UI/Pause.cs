using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
  public static bool GameisPaused = false;

  [SerializeField]
  private GameObject pauseMenu;

  public void OnGamePaused(InputAction.CallbackContext context)
  {
    if (GameisPaused)
    {
      Resume();
    }
    else
    {
      Paused();
    }
  }

  public void Resume()
  {
    pauseMenu.SetActive(false);
    Time.timeScale = 1f;
    GameisPaused = false;
  }

  public void Paused()
  {
    pauseMenu.SetActive(true);
    Time.timeScale = 0f;
    GameisPaused = true;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Menu");
  }
}
