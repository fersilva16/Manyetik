using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public float jumpForce;

  private Rigidbody2D rigidBody;

  void Start()
  {
    rigidBody = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    Move();
    Jump();
  }

  public void Move()
  {
    var force = new Vector2(Input.GetAxis("Horizontal"), 0);

    rigidBody.position += speed * force * Time.deltaTime;
  }

  public void Jump()
  {
    if (Input.GetButton("Jump") && rigidBody.velocity.y == 0)
    {
      rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
  }
}
