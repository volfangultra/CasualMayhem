using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 2f;

    private Vector2 moveDirection;

    void Start()
    {
        // Destroy the water after some time
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move in the set direction
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction;
    }
}
