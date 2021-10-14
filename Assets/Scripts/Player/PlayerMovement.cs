using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  private float speed;

  [Range(0, .3f)]
  [SerializeField]
  private float movementSmoothing;

  private new Rigidbody2D rigidbody2D;

  private float direction;
  private Vector2 velocity;

  private void OnEnable() => InputManager.Movement += OnMovementInput;
  private void OnDisable() => InputManager.Movement -= OnMovementInput;

  private void Start()
  {
    rigidbody2D = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    Move();
  }

  private void OnMovementInput(InputAction.CallbackContext context)
  {
    direction = context.ReadValue<float>();
  }

  private void Move()
  {
    var targetVelocity = new Vector2(direction * speed, rigidbody2D.velocity.y);

    rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);
  }

  public float GetDirection() => direction;
}
