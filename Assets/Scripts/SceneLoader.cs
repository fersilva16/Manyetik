using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  [Scene] public string scene;
  public bool nextScene;

  public void OnCollisionEnter2D(Collision2D collider)
  {
    if (collider.gameObject.CompareTag("Player")) LoadScene();
  }

  public void LoadScene()
  {
    if (!nextScene) SceneManager.LoadScene(scene);
    else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
