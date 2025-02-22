using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    public float speed;
    public LayerMask groundLayer;
    public Transform feetPosition;
    public GameObject gameOverScreen;

    public float groundCheckCircle;
    private bool isGrounded;
    private Animator animator;
    private float input;
    private bool isGameOver = false;
    private bool isDucking;
    public Collider2D normalCollider;
    public Collider2D duckCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Return)) // Enter key
        {
            RestartGame();
        }

        input = Input.GetAxisRaw("Horizontal");

        // Flip sprite based on movement direction
        if (input < 0)
            spriteRenderer.flipX = true;
        else if (input > 0)
            spriteRenderer.flipX = false;

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        // Jump logic
        if (Input.GetButtonDown("Jump") && isGrounded) // Prevent jumping while ducking
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
        }

        // Duck logic
        if (Input.GetAxisRaw("Vertical") < 0) // Only allow ducking on the ground
        {
            if (!isDucking) // Only trigger once
            {
                isDucking = true;
                animator.SetTrigger("Duck"); // Use a trigger to start the animation once
                normalCollider.enabled = false;
                duckCollider.enabled = true;
            }
        }
        else if (isDucking) // When releasing down key, finish animation before exiting duck state
        {
            isDucking = false;
            normalCollider.enabled = true;
            duckCollider.enabled = false;
            animator.Play("Idle");
        }

        // Set animator parameter for walking (only if not ducking)
        animator.SetBool("isWalking", input != 0 && !isDucking);
    }


    void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D other) // For 2D Collisions
    {
        if (other.CompareTag("CanKill")) // Make sure your obstacle has the "Obstacle" tag
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true); // Show Game Over UI
        Time.timeScale = 0; // Pause the game
        isGameOver = true;
    }

    void RestartGame()
    {
        Time.timeScale = 1; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
    }
    IEnumerator FinishDucking()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Wait for animation to finish

        Debug.Log("Finishing");
    }

}

