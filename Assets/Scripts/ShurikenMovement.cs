using UnityEngine;

public class ShurikenMovement : MonoBehaviour
{

    public float speed = 0.2f;
    public float rotationSpeed = 360f; // Degrees per second
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        // Move pigeon to the left
        transform.position += Vector3.left * speed;
        transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);

    }
}
