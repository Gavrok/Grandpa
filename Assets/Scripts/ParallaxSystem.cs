using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{
    public Transform layer; // The layer to apply the parallax effect
    public float parallaxFactor; // How much the layer moves relative to the camera movement
}

public class ParallaxSystem : MonoBehaviour
{
    public List<ParallaxLayer> layers = new List<ParallaxLayer>(); // List of all parallax layers
    private Vector3 lastCameraPosition; // To store the position of the camera in the last frame

    private void Start()
    {
        // Initialize lastCameraPosition with the current camera position at the start
        lastCameraPosition = Camera.main.transform.position;
    }

    private void FixedUpdate()
    {
        // Calculate the movement of the camera since the last frame
        Vector3 deltaMovement = Camera.main.transform.position - lastCameraPosition;
        // Update lastCameraPosition with the current camera position for the next cycle
        lastCameraPosition = Camera.main.transform.position;

        // Apply the parallax effect to each layer
        foreach (ParallaxLayer layer in layers)
        {
            // Calculate the new position for the layer, adjusting only the x position based on the parallax factor
            // Keep the y position unchanged to prevent vertical movement
            Vector3 newPosition = layer.layer.position + new Vector3(deltaMovement.x * layer.parallaxFactor, 0, 0);

            // Update the layer's position
            layer.layer.position = new Vector3(newPosition.x, layer.layer.position.y, layer.layer.position.z);
        }
    }
}