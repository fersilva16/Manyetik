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
  private Vector3 horizontalOffset;

  private void Start()
  {
    collider = GetComponent<BoxCollider2D>();
    rigidbody2D = GetComponent<Rigidbody2D>();

    groundDistance = collider.size.y / 2 + groundDistanceOffset;
    horizontalOffset = new Vector3(collider.size.x / 2, 0, 0);
  }

  private void FixedUpdate()
  {
    var raycast1 = Physics2D.Raycast(transform.position + horizontalOffset, Vector2.down, groundDistance, groundLayer);
    var raycast2 = Physics2D.Raycast(transform.position - horizontalOffset, Vector2.down, groundDistance, groundLayer);

    grounded = raycast1.collider != null || raycast2.collider != null;
  }

  private void OnJumpInput(InputAction.CallbackContext context)
  {
    if (!grounded) return;

    rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
  }
}
