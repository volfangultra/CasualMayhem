using NUnit.Framework.Internal;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    private float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    private Animator animator;

    public LayerMask groundLayer;
    public Transform feetPosition;
    public float groundCheckCircle;
    private bool isGrounded;

    private bool isDucking;
    public Collider2D normalCollider;
    public Collider2D duckCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        // Flip sprite based on movement direction
        if (input < 0)
            spriteRenderer.flipX = true;
        else if (input > 0)
            spriteRenderer.flipX = false;

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        // Jump logic
        //if (Input.GetButtonDown("Jump") && isGrounded && !isDucking) dont allow jump ducking
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
        }

        // Duck logic
        //if (Input.GetAxisRaw("Vertical") < 0 && isGrounded) dont allow ducking in air
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            isDucking = true;
            //animator.SetBool("isDucking", true);
            normalCollider.enabled = false;
            duckCollider.enabled = true;
        }
        else
        {
            isDucking = false;
            //animator.SetBool("isDucking", false);
            normalCollider.enabled = true;
            duckCollider.enabled = false;
        }

        // Set animator parameter for walking (only if not ducking)
        animator.SetBool("isWalking", input != 0 && !isDucking);
    }

    void FixedUpdate()
    {
        // Allow movement only if not ducking
        // if (!isDucking) //dont allow moving when ducking
        // {
        //     playerRb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);
        // }

        playerRb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);

    }
}
