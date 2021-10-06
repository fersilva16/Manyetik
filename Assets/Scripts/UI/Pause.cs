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
    animationPM.SetTrigger("Close");
    Time.timeScale = 1f;
    GameisPaused = false;
  }

  public void Paused()
  {
    animationPM.SetTrigger("Open");
    Time.timeScale = 0f;
    GameisPaused = true;
  }

  public void LoadMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Menu");
  }

}
