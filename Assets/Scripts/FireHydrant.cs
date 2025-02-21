using System.Collections;
using UnityEngine;

public class FireHydrant : MonoBehaviour
{
    public float waterSpeed = 5f;
    public float waterLifetime = 2f;
    public Sprite waterSprite;

    void Start()
    {
        StartCoroutine(ShootWater());
    }

    IEnumerator ShootWater()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); // Wait for 3 seconds

            // Spawn water on both sides
            SpawnWater(Vector2.left);
            SpawnWater(Vector2.right);
        }
    }

    void SpawnWater(Vector2 direction)
    {
        // Create a new GameObject for water
        GameObject water = new GameObject("Water");

        // Add SpriteRenderer and assign the user-defined sprite
        SpriteRenderer sr = water.AddComponent<SpriteRenderer>();
        if (waterSprite != null)
        {
            sr.sprite = waterSprite;
        }
        else
        {
            Debug.LogWarning("Water sprite not assigned!");
        }
        sr.sortingLayerName = "Ground"; // Adjust sorting layer as needed

        // Add Rigidbody2D for movement
        Rigidbody2D rb = water.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0; // No gravity
        rb.linearVelocity = direction * waterSpeed;

        // Set position slightly offset so it's not inside the hydrant
        water.transform.position = transform.position + new Vector3(direction.x * 0.5f, 0, 0);
        water.transform.localScale = new Vector3(0.5f, 0.5f, 1); // Adjust size

        // Destroy after some time
        Destroy(water, waterLifetime);
    }
}
