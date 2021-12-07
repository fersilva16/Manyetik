using UnityEngine;

public class PauseToRead : MonoBehaviour
{
  [SerializeField]
  private GameObject textBox;

  private void Update()
  {
    if (PauseMenu.isPaused) return;

    Time.timeScale = textBox.activeSelf ? 0f : 1f;
  }
}
