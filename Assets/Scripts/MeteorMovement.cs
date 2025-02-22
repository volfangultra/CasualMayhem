using Unity.VisualScripting;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{

    public float speed = 0.3f;

    void FixedUpdate()
    {
        // Move pigeon to the left
        transform.position += Vector3.left * speed + Vector3.down * speed;
        if(transform.position.y < -7)
            Destroy(gameObject);

    }

}
