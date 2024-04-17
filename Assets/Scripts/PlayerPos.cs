using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private CheckpointSystem cps;
    void Start()
    {
        cps = GameObject.FindGameObjectWithTag("CPS").GetComponent<CheckpointSystem>();
        transform.position = cps.lastCheckpoint;
    }

    public void MoveToLastCheckpoint()
    {
        if (cps == null)
        {
            cps = GameObject.FindGameObjectWithTag("CPS").GetComponent<CheckpointSystem>();
        }

        if (cps != null && cps.lastCheckpoint != null)
        {
            transform.position = cps.lastCheckpoint;
        }
        else
        {
            Debug.LogError("Checkpoint System or last checkpoint is not set.");
        }
    }
}
