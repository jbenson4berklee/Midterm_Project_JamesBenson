using UnityEngine;

public class FallDetectionBehavior : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -40.0f)
        {
            transform.position = Vector3.zero;
        }
    }
}
