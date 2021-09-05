using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public float jumpForce;
  public Sprite body;
  public Sprite invertedBody;
  public Component north;
  public Component south;

  private Animator animator;
  private new Rigidbody2D rigidbody2D;

  private int positiveLayer;
  private int negativeLayer;
  
  public void Start()
  {
    rigidbody2D = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();

    positiveLayer = LayerMask.NameToLayer("Positive");
    negativeLayer = LayerMask.NameToLayer("Negative");
  }

  public void Update()
  {
    Move();
    Jump();
    InvertPoles();
  }

  private void Move()
  {
    var force = new Vector2(Input.GetAxis("Horizontal"), 0);

    rigidbody2D.position += speed * force * Time.deltaTime;

    animator.SetBool("Walk", Input.GetAxis("Horizontal") != 0);
    transform.eulerAngles = new Vector2(0, Input.GetAxis("Horizontal") < 0 ? 180 : 0);
  }

  private void Jump()
  {
    if (Input.GetButton("Jump") && rigidbody2D.velocity.y == 0)
    {
      rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
  }

  private void InvertPoles()
  {
    if (Input.GetButtonDown("InvertPoles"))
    {
      animator.SetBool("Inverted", !animator.GetBool("Inverted"));
      SetPoleLayer(north.gameObject);
      SetPoleLayer(south.gameObject);
    }
  }

  private void SetPoleLayer(GameObject gameObject)
  {
    gameObject.layer = gameObject.layer == positiveLayer ? negativeLayer : positiveLayer;
  }
}
