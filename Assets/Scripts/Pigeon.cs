using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // Move pigeon to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

    }

}

