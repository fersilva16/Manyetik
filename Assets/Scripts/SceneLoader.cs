using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public Animator transition;
  public float transitionTime;


  [Scene] public string scene;
  public bool nextScene;

  public void OnCollisionEnter2D(Collision2D collider)
  {
    if (collider.gameObject.CompareTag("Player")) LoadNextScene();
  }

  public void LoadNextScene()
  {
    if (!nextScene) SceneManager.LoadScene(scene);

    else StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
  }

  IEnumerator LoadScene(int levelIndex) 
  {
    transition.SetTrigger("Start");

    yield return new WaitForSeconds (transitionTime);

    SceneManager.LoadScene(levelIndex);
  }
}
