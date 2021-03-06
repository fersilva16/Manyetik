using UnityEngine;

public class Menu : MonoBehaviour
{
  private Animator animator;

  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  public void Open() => animator.Play("Open");
  public void Close() => animator.Play("Close");
}
