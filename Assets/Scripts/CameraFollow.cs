using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 offset;

    //Nakon playera mrni kameru (zato Late)
    void FixedUpdate()
    {
        transform.position += offset;
    }

}
