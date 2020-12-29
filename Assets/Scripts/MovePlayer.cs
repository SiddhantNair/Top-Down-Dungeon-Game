using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rbody;
    private Vector2 moveVector;
    private Vector2 oldInput;
    private BoxCollider2D boxCollider;
    private AudioSource hitSound;
    public HealthManager healthManager;
    private float lookDir;
    public float speed;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        hitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hitSound.Play();
            healthManager.health -= 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetBool("hurt", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetBool("hurt", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("hurt");
            Physics2D.IgnoreCollision(collision.collider, boxCollider);
        }
    }

    private void flattenInput()
    {
        if (moveVector.x > 0)
        {
            moveVector.x = 1;
            lookDir = 0;
        }
        else if (moveVector.x < 0)
        {
            moveVector.x = -1;
            lookDir = 180;
        }
        else
        {
            moveVector.x = 0;
        }
        if (moveVector.y > 0)
        {
            moveVector.y = 1;
        }
        else if (moveVector.y < 0)
        {
            moveVector.y = -1;
        }
        else
        {
            moveVector.y = 0;
        }
    }

    private void FixedUpdate()
    {
        moveVector = new Vector2();
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        flattenInput();

        if (moveVector.x == 0 || moveVector.y == 0)
        {
            oldInput = new Vector2(moveVector.x, moveVector.y);
        }
        else
        {
            if (Mathf.Abs(moveVector.x) > Mathf.Abs(moveVector.y))
            {
                moveVector.y = 0;
            }
            else if (Mathf.Abs(moveVector.x) < Mathf.Abs(moveVector.y))
            {
                moveVector.x = 0;
            }
            else
            {
                if (oldInput == Vector2.zero)
                {
                    if (moveVector.y == 1)
                    {
                        oldInput = new Vector2(0, 1);
                    }
                    else if (moveVector.y == -1)
                    {
                        oldInput = new Vector2(0, -1);
                    }
                }
                moveVector -= oldInput;     
            }
        }

        transform.rotation = Quaternion.Euler(0, lookDir, 0);
        moveVector = moveVector * speed * Time.deltaTime;

        moveVector = new Vector2(Mathf.RoundToInt(moveVector.x * 16), Mathf.RoundToInt(moveVector.y * 16)) / 16;

        animator.SetFloat("velocity", Mathf.Abs(moveVector.magnitude));
        rbody.MovePosition(new Vector2(transform.position.x, transform.position.y) + moveVector);
    }
}
