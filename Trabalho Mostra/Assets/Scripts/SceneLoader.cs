using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public string sceneName;
  public bool nextLevel;

  private void OnCollisionEnter2D(Collision2D collider)
  {
    if (collider.gameObject.CompareTag("Player")) LoadScene();
  }

  public void LoadScene()
  {
    if (!nextLevel)
    {
      SceneManager.LoadScene(sceneName);

      return;
    }

    var currentName = SceneManager.GetActiveScene().name;
    var currentLevel = float.Parse(currentName.Substring(currentName.Length - 1));

    SceneManager.LoadScene("Level" + (currentLevel + 1));
  }
}
