using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTunerOnLevelLoad : MonoBehaviour
{
    public MonoBehaviour RadioControl;
    // Start is called before the first frame update
    void Start()
    {
        if (RadioControl != null)
        {
            RadioControl.enabled = true;
            Debug.Log("Activated the script!");
        }
        else
        {
            Debug.Log("No script assigned to activate.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
