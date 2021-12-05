using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseToRead : MonoBehaviour
{
  [SerializeField]
  private GameObject textBox;

  void Update()
  {
    if(textBox.activeSelf == true)
    {
      Time.timeScale = 0f;
    }else
    {
      Time.timeScale = 1f;
    }
  }
}
