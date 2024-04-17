using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockActivate : MonoBehaviour
{
    public GameObject Acieve1Pic;
    // Start is called before the first frame update
    void Start()
    {
       if (GameManagerBools.Instance != null && GameManagerBools.Instance.Achievement1)
        {
            Acieve1Pic.SetActive(true);
        }
    }

}
