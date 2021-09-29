using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField]
  private float speed;

  [Range(0, .3f)]
  [SerializeField]
  private float movementSmoothing;

  [SerializeField]
  private float jumpForce;

  [SerializeField]
  private Component north;

  [SerializeField]
  private Component south;

  [SerializeField]
  private LayerMask groundLayer;

  [SerializeField]
  [Layer]
  private int positiveLayer;

  [SerializeField]
  [Layer]
  private int negativeLayer;

  [SerializeField]
  [Layer]
  private int fireLayer;

  [SerializeField]
  [Layer]
  private int magnetiteLayer;

  private PlayerAnimator animator;
  private new BoxCollider2D collider;
  private new Rigidbody2D rigidbody2D;

  private float direction;
  private bool grounded;
  private Vector2 velocity;

  private float groundDistance;

  private void Start()
  {
    animator = GetComponent<PlayerAnimator>();
    collider = GetComponent<BoxCollider2D>();
    rigidbody2D = GetComponent<Rigidbody2D>();

    groundDistance = collider.size.y / 2 + .1f;
  }

  private void Update()
  {
    CheckGrounded();

    Move();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.layer == fireLayer) ChangeMagnetized(false);
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.layer == magnetiteLayer) ChangeMagnetized(true);
  }

  public void OnMovementInput(InputAction.CallbackContext context)
  {
    direction = context.ReadValue<float>();
  }

  public void OnJumpInput(InputAction.CallbackContext context)
  {
    if (!grounded) return;

    rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
  }

  public void OnInvertInput(InputAction.CallbackContext context)
  {
    animator.Inverted = !animator.Inverted;

    // SwitchPoleLayer(north);
    // SwitchPoleLayer(south);
  }

  private void CheckGrounded()
  {
    var raycast = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);

    grounded = raycast.collider != null;
  }

  private void Move()
  {
    var targetVelocity = new Vector2(direction * speed, rigidbody2D.velocity.y);

    rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

    animator.Horizontal = direction;
  }

  private void ChangeMagnetized(bool value)
  {
    animator.Magnetized = value;
    north.gameObject.SetActive(value);
    south.gameObject.SetActive(value);
  }

  private void SwitchPoleLayer(Component pole)
  {
    pole.gameObject.layer = pole.gameObject.layer == positiveLayer ? negativeLayer : positiveLayer;
  }
}
