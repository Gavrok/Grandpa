using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockActivate3 : MonoBehaviour
{
    public GameObject Acieve3Pic;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerBools.Instance != null && GameManagerBools.Instance.Achievement3)
        {
            Acieve3Pic.SetActive(true);
        }
    }

}
