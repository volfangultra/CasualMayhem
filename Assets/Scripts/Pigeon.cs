using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public float speed = 0.2f;
    public GameObject poopPrefab;  // Prefab for the pigeon poop
    public float poopSpawnInterval = 3f; // Interval for spawning poop (in seconds)

    void Start()
    {
        // Start spawning poop at the specified interval
        InvokeRepeating("SpawnPoop", 0f, poopSpawnInterval);
    }

    void FixedUpdate()
    {
        // Move pigeon to the left
        transform.position += Vector3.left * speed;
    }

    // Function to spawn poop
    void SpawnPoop()
    {
        // Instantiate the poop prefab at the pigeon's current position
        Instantiate(poopPrefab, transform.position, Quaternion.identity);
        
    }
}
