using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
  private static DontDestroyMusic instance;

  void Awake()
  {
    if(instance != null)
    {
      Destroy(gameObject);
    }
    else
    {
      instance = this;
      DontDestroyOnLoad(transform.gameObject);
    }
  }
}
