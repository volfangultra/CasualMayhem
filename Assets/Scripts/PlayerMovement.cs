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

    void Start()
    {
        // Get the Animator component
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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
        }

        // Set animator parameter for walking
        animator.SetBool("isWalking", input != 0);
    }

    void FixedUpdate()
    {
        // Only modify x velocity, keeping y velocity unchanged
        playerRb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);
    }
}
