using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectExplosion : MonoBehaviour
{
    public float explosionRadius = 5f;
    public CameraShake explosionShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayerInRange();
    }

    void CheckForPlayerInRange()
    {
        // Detect all colliders within the explosion radius
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            // Check if any of the colliders have the tag "Player"
            if (hitCollider.CompareTag("Explosion"))
            {
                // Log a message to the Console
                Debug.Log("Player found within explosion radius.");
                explosionShake.CamerShake();
                Debug.Log("camera shaking");
            }
        }
    }
}
