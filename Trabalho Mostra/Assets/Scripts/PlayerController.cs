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
  private new SpriteRenderer renderer;

  private int positiveLayer;
  private int negativeLayer;
  
  void Start()
  {
    rigidbody2D = GetComponent<Rigidbody2D>();
    renderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();

    positiveLayer = LayerMask.NameToLayer("Positive");
    negativeLayer = LayerMask.NameToLayer("Negative");
  }

  void Update()
  {
    Move();
    Jump();
    InvertPoles();
  }

  private void Move()
  {
    var force = new Vector2(Input.GetAxis("Horizontal"), 0);

    rigidbody2D.position += speed * force * Time.deltaTime;

    if(Input.GetAxis("Horizontal") > 0f)
    {
      animator.SetBool("Walk", true);
      transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

     if(Input.GetAxis("Horizontal") < 0f)
    {
      animator.SetBool("Walk", true);
      transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

     if(Input.GetAxis("Horizontal") == 0f)
    {
      animator.SetBool("Walk", false);
    }
    
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
