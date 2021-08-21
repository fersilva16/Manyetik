using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public float jumpForce;
  public Sprite body;
  public Sprite invertedBody;
  public Component north;
  public Component south;
  public Animator anim;

  private new Rigidbody2D rigidbody2D;
  private new SpriteRenderer renderer;
  private CircleCollider2D northCollider;
  private CircleCollider2D southCollider;
                                             
  void Start()
  {
    rigidbody2D = GetComponent<Rigidbody2D>();
    renderer = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();

    northCollider = north.GetComponent<CircleCollider2D>();
    southCollider = south.GetComponent<CircleCollider2D>();
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
      anim.SetBool("Walk", true);
      transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

     if(Input.GetAxis("Horizontal") < 0f)
    {
      anim.SetBool("Walk", true);
      transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

     if(Input.GetAxis("Horizontal") == 0f)
    {
      anim.SetBool("Walk", false);
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
      renderer.sprite = renderer.sprite.name == body.name ? invertedBody : body;
      north.gameObject.layer = GetPoleLayer(north.gameObject.layer);
      south.gameObject.layer = GetPoleLayer(south.gameObject.layer);
    }
  }

  private int GetPoleLayer(int currentLayer)
  {
    return currentLayer == 6 ? 7 : 6;
  }
}
