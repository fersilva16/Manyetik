using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
  private static DontDestroyMusic instance;

  private void Awake()
  {
    if (instance != null) Destroy(gameObject);
    else
    {
      instance = this;
      DontDestroyOnLoad(transform.gameObject);
    }
  }
}
