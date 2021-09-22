using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  [SerializeField]
  private Animator transition;

  [SerializeField]
  private float transitionTime;

  [SerializeField]
  [Scene]
  private string scene;

  [SerializeField]
  private bool nextScene;

  private void OnCollisionEnter2D(Collision2D collider)
  {
    if (collider.gameObject.CompareTag("Player")) LoadNextScene();
  }

  public void LoadNextScene()
  {
    if (!nextScene) SceneManager.LoadScene(scene);
    else StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
  }

  private IEnumerator LoadScene(int levelIndex)
  {
    transition.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);

    SceneManager.LoadScene(levelIndex);
  }
}
