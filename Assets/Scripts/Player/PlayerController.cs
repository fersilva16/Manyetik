using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public float jumpForce;

  [Space]
  public Component north;
  public Component south;

  [Space]
  public LayerMask groundLayer;
  [Layer] public int positiveLayer;
  [Layer] public int negativeLayer;

  [Space]
  [Layer] public int fireLayer;
  [Layer] public int magnetiteLayer;

  private PlayerAnimator animator;
  private new BoxCollider2D collider;
  private new Rigidbody2D rigidbody2D;

  private float direction;
  private bool grounded;

  private float groundDistance;

  public void Start()
  {
    animator = GetComponent<PlayerAnimator>();
    collider = GetComponent<BoxCollider2D>();
    rigidbody2D = GetComponent<Rigidbody2D>();

    groundDistance = collider.size.y / 2 + .1f;
  }

  public void Update()
  {
    CheckGrounded();

    Move();
  }

  public void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.layer == fireLayer) ChangeMagnetized(false);
  }

  public void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.layer == magnetiteLayer) ChangeMagnetized(true);
  }

  public void OnMovementInput(InputAction.CallbackContext context)
  {
    direction = context.ReadValue<float>();

    animator.Horizontal = direction;
  }

  public void OnJumpInput(InputAction.CallbackContext context)
  {
    if (!context.performed || !grounded) return;

    rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
  }

  public void OnInvertInput(InputAction.CallbackContext context)
  {
    if (!context.performed) return;

    animator.Inverted = !animator.Inverted;

    SwitchPoleLayer(north);
    SwitchPoleLayer(south);
  }

  private void CheckGrounded()
  {
    var raycast = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);

    grounded = raycast.collider != null;
  }

  private void Move()
  {
    rigidbody2D.position += direction * speed * Time.deltaTime * Vector2.right;
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
