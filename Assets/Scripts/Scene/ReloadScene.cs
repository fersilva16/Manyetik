using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
  public void Reload()
  {
    Time.timeScale = 1f;

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
