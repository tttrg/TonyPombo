using UnityEngine;

public class IsoCameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(10, 10, -10);
    public float smoothSpeed = 0.125f;
    public float jumpDistanceFactor = 1.5f; 
    public float smoothTime = 0.3f;

    private Vector3 currentVelocity;
    private Vector3 originalOffset;
    private Rigidbody targetRb;

    void Start()
    {
        targetRb = target.GetComponent<Rigidbody>();
        originalOffset = offset;
    }

    void LateUpdate()
    {
        
        Vector3 adjustedOffset = originalOffset;

        
        if (targetRb.velocity.y > 0)
        {
            adjustedOffset *= jumpDistanceFactor;
        }
 
        Vector3 desiredPosition = target.position + adjustedOffset;
        
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);
        
        transform.LookAt(target);
    }
}