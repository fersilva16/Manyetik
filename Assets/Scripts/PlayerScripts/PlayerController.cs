using UnityEngine;

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

  private PlayerAnimator animator;
  private new BoxCollider2D collider;
  private new Rigidbody2D rigidbody2D;

  private float horizontal;
  private bool jump;
  private bool invert;
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
    horizontal = Input.GetAxis("Horizontal");
    jump = jump || Input.GetButtonDown("Jump");
    invert = invert || Input.GetButtonDown("Invert");

    animator.Horizontal = horizontal;
  }

  public void FixedUpdate()
  {
    grounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer).collider != null;

    var accelaration = new Vector2(horizontal, 0);

    rigidbody2D.position += accelaration * speed * Time.fixedDeltaTime;

    if (grounded) {
      if (jump) rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

      // animator.Jumping = jump;
    }

    if (invert)
    {
      animator.Inverted = !animator.Inverted;

      SwitchPoleLayer(north);
      SwitchPoleLayer(south);
    }

    jump = false;
    invert = false;
  }

  private void SwitchPoleLayer(Component pole)
  {
    pole.gameObject.layer = pole.gameObject.layer == positiveLayer ? negativeLayer : positiveLayer;
  }
}
