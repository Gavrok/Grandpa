using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private static CheckpointSystem instance;
    public Vector2 lastCheckpoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
