using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePanel : MonoBehaviour
{
  [SerializeField] GameObject painel;

  void Start()
  {
    painel.SetActive(true);
    Time.timeScale = 0f;
  }

  public void Resume()
  {
    painel.SetActive(false);
    Time.timeScale = 1f;
  }
}
