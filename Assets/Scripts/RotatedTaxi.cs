using UnityEngine;

public class RotatedTaxi : MonoBehaviour
{
    public float shrinkDuration = 2f; // Total shrink time
    private Vector3 initialScale;
    private Vector3 targetScale; // Target scale (half the original)

    void Start()
    {
        initialScale = transform.localScale;
        targetScale = initialScale * 0.5f; // Half the original scale
        StartCoroutine(ShrinkAndDestroy());
    }

    private System.Collections.IEnumerator ShrinkAndDestroy()
    {
        float timer = 0f;
        while (timer < shrinkDuration)
        {
            timer += Time.deltaTime;

            // Interpolate towards half scale
            transform.localScale = Vector3.Lerp(initialScale, targetScale, timer / shrinkDuration);

            // Stop shrinking if we've reached half scale
            if (transform.localScale.magnitude <= targetScale.magnitude)
            {
                break;
            }

            yield return null;
        }

        // Destroy after reaching half size
        Destroy(gameObject);
    }
}
