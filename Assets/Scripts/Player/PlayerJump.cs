using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
  [SerializeField]
  private float jumpForce;

  [Header("Ground check")]
  [SerializeField]
  private LayerMask groundLayer;

  [SerializeField]
  private float groundDistanceOffset;

  private void OnEnable() => InputManager.Jump += OnJumpInput;
  private void OnDisable() => InputManager.Jump -= OnJumpInput;

  private new BoxCollider2D collider;
  private new Rigidbody2D rigidbody2D;

  private bool grounded;
  private float groundDistance;

  private void Start()
  {
    collider = GetComponent<BoxCollider2D>();
    rigidbody2D = GetComponent<Rigidbody2D>();

    groundDistance = collider.size.y / 2 + groundDistanceOffset;
  }

  private void FixedUpdate()
  {
    CheckGrounded();
  }

  private void OnJumpInput(InputAction.CallbackContext context)
  {
    if (!grounded) return;

    rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
  }

  private void CheckGrounded()
  {
    var raycast = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);

    grounded = raycast.collider != null;
  }
}
