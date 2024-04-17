using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadDetector : MonoBehaviour
{
    public DementiaLevel DementiaIncrease;
    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe to ensure clean up
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Log a message whenever a scene is loaded
        Debug.Log($"Scene {scene.name} has been loaded.");
        DementiaIncrease.IncrementStage();
    }
}
