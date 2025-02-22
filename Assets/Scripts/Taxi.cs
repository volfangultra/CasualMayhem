using UnityEngine;

public class Taxi : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public float lifespan = 3f; // Time before switching
    public GameObject rotatedTaxiPrefab; // Prefab reference

    private float timer;

    void FixedUpdate()
    {
        // Move left
        transform.position += Vector3.left * speed;

        // Check lifespan
        timer += Time.fixedDeltaTime;
        if (timer >= lifespan)
        {
            ReplaceWithRotatedTaxi();
        }
    }

    void ReplaceWithRotatedTaxi()
    {
        // Instantiate the rotated taxi prefab at the same position and rotation
        if (rotatedTaxiPrefab != null)
        {
            Instantiate(rotatedTaxiPrefab, transform.position, Quaternion.identity);
        }

        // Destroy this Taxi object
        Destroy(gameObject);
    }
}
