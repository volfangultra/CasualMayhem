using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float parallexEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallexEffect;
        float movement = cam.transform.position.x * (1 - parallexEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        // Debug.Log("Cam X: " + cam.transform.position.x + " | StartPos: " + startPos + " | Length: " + length);

        // if (movement > startPos + length)
        // {
        //     startPos += length;
        // }
        // else if (movement < startPos - length)
        // {
        //     startPos -= length;
        // }
    }
}
