using System.Collections;
using UnityEngine;

public class FireHydrant : MonoBehaviour
{
    public float waterSpeed = 5f;
    public GameObject waterPrefab;

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
        if (waterPrefab == null)
        {
            Debug.LogWarning("Water prefab not assigned!");
            return;
        }

        // Instantiate the water prefab
        GameObject water = Instantiate(waterPrefab, transform.position + (Vector3)(direction * 7f), Quaternion.identity);

        // Flip the sprite if moving right
        SpriteRenderer sprite = water.GetComponent<SpriteRenderer>();
        if (sprite != null && direction == Vector2.right)
        {
            sprite.flipX = true;
        }

        // Set movement direction inside the prefab script
        WaterProjectile waterScript = water.GetComponent<WaterProjectile>();
        if (waterScript != null)
        {
            waterScript.SetDirection(direction);
        }
    }
}
