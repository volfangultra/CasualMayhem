using UnityEngine;

public class MeteorMovement : MonoBehaviour
{

    public float speed = 0.3f;

    void FixedUpdate()
    {
        // Move pigeon to the left
        transform.position += Vector3.left * speed + Vector3.down * speed;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Ground")) // Make sure the ground has the tag "Ground"
        {
            Destroy(gameObject); // Destroy the meteor when it hits the ground
        }
    }

}
