using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;
    private SpriteRenderer spriteRenderer;
    private AudioSource slashSound;
    private Animator animator;

    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        slashSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        polygonCollider.enabled = false;
        spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.name == "Player"))
        {
            slashSound.Play();
        }
    }

    public void hideWeapon()
    {
        polygonCollider.enabled = false;
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            polygonCollider.enabled = true;
            spriteRenderer.enabled = true;
            animator.SetTrigger("attack");
        }
    }
}
