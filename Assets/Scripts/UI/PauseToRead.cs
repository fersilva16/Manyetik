using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseToRead : MonoBehaviour
{
  [SerializeField]
  private GameObject textBox;

  void Update()
  {
    Time.timeScale = textBox.activeSelf ? 0f : 1f;
  }
}
