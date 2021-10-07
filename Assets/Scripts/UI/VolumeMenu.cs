using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
  private Animator animator;

  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  public void Open()
  {
    animator.Play("Open");
  }

  public void Close()
  {
    animator.Play("Close");
  }

}
