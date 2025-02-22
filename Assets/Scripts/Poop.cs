using UnityEngine;
using System.Collections;

public class Poop : MonoBehaviour
{
    public Sprite[] poopSprites; // Array to hold the sprites
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    void Start()
    {
        // Get the SpriteRenderer component attached to the poop
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start the coroutine to change sprites every 0.5 seconds
        StartCoroutine(ChangeSprite());
    }

    // Coroutine to change the sprite every 0.5 seconds
    IEnumerator ChangeSprite()
    {
        // Loop through the sprites
        while (currentSpriteIndex < poopSprites.Length)
        {
            // Change the sprite
            spriteRenderer.sprite = poopSprites[currentSpriteIndex];
            
            // Wait for 0.5 seconds before changing to the next sprite
            yield return new WaitForSeconds(0.2f);
            
            // Increment the index
            currentSpriteIndex++;
        }

        // After the last sprite, keep the final sprite
        spriteRenderer.sprite = poopSprites[poopSprites.Length - 1];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) // Make sure the ground has the tag "Ground"
        {
            Destroy(gameObject); // Destroy the poop when it hits the ground
        }
    }
}