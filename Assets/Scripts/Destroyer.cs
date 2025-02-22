using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)  
    {
        if (collision.gameObject.tag != "Ground")
        {
            // Destroy the object that collided with this one
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)  
    {
        if (collision.gameObject.tag != "Ground")
        {
            // Destroy the object that collided with this one
            Destroy(collision.gameObject);
        }
    }
}
