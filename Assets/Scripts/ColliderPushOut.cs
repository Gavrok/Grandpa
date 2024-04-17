using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPusher : MonoBehaviour
{
    [Tooltip("Direction and magnitude of the push. Can be set in the inspector.")]
    public Vector3 pushDirection = Vector3.back;
    public float pushForce = 5.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Normalize the push direction to ensure consistent force application
            Vector3 normalizedPushDirection = pushDirection.normalized;

            // Apply the push force
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(normalizedPushDirection * pushForce, ForceMode.VelocityChange);
            }
        }
    }
}
