using System.Text;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
  private Animator animator;

  public bool Magnetized { get; set; }
  public bool Inverted { get; set; }
  public float Horizontal { get; set; }
  public bool Jumping { get; set; }

  private string currentAnimation;

  private string Direction
  {
    get {
      if (string.IsNullOrEmpty(currentAnimation)) return "Right";

      if (currentAnimation.IndexOf("Left") != -1) return "Left";
      else return "Right";
    }
  }

  private void Start()
  {
    animator = GetComponent<Animator>();

    Magnetized = true;
  }

  private void Update()
  {
    var animation = new StringBuilder();

    if (Jumping) animation.Append("Jump");
    else if (Horizontal != 0) animation.Append("Run");
    else animation.Append("Idle");

    if (!Magnetized) animation.Append("Iron");
    else if (Inverted) animation.Append("Inverted");

    if (Horizontal > 0) animation.Append("Right");
    else if (Horizontal < 0) animation.Append("Left");
    else animation.Append(Direction);

    UpdateAnimation(animation.ToString());
  }

  private void UpdateAnimation(string animation)
  {
    if (currentAnimation != animation)
    {
      animator.Play(animation);

      currentAnimation = animation;
    }
  }
}
