using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckpointSystem cps;
    void Start()
    {
        cps = GameObject.FindGameObjectWithTag("CPS").GetComponent<CheckpointSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cps.lastCheckpoint = transform.position;
        }
    }
}
