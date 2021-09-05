using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public string sceneName;
  public bool nextScene;

  public void OnCollisionEnter2D(Collision2D collider)
  {
    if (collider.gameObject.CompareTag("Player")) LoadScene();
  }

  public void LoadScene()
  {
    if (!nextScene) SceneManager.LoadScene(sceneName);
    else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
