using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
  private Animator animator;
  private new Rigidbody2D rigidbody2D;
  private PlayerMagnetism magnetism;
  private PlayerMovement movement;

  private string currentAnimation;

  private bool inverted;

  private void OnEnable() => InputManager.Invert += OnInvertInput;
  private void OnDisable() => InputManager.Invert += OnInvertInput;

  private void Start()
  {
    animator = GetComponent<Animator>();
    rigidbody2D = GetComponent<Rigidbody2D>();

    magnetism = GetComponent<PlayerMagnetism>();
    movement = GetComponent<PlayerMovement>();
  }

  private void OnInvertInput(InputAction.CallbackContext _) => inverted = !inverted;

  private string GetCurrentDirection()
  {
    if (string.IsNullOrEmpty(currentAnimation)) return "Right";

    if (currentAnimation.IndexOf("Left") != -1) return "Left";

    return "Right";
  }

  private void Update()
  {
    var vertical = 0; // rigidbody2D.velocity.y;

    var stringBuilder = new StringBuilder();

    if (vertical > 0) stringBuilder.Append("Jump");
    else if (movement.GetDirection() != 0) stringBuilder.Append("Run");
    else stringBuilder.Append("Idle");

    if (!magnetism.IsMagnetized()) stringBuilder.Append("Iron");
    else if (inverted) stringBuilder.Append("Inverted");

    if (movement.GetDirection() > 0) stringBuilder.Append("Right");
    else if (movement.GetDirection() < 0) stringBuilder.Append("Left");
    else stringBuilder.Append(GetCurrentDirection());

    var animation = stringBuilder.ToString();

    if (currentAnimation != animation)
    {
      animator.Play(animation);

      currentAnimation = animation;
    }
  }
}
