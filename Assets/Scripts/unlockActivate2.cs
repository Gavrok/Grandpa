using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockActivate2 : MonoBehaviour
{
    public GameObject Acieve2Pic;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerBools.Instance != null && GameManagerBools.Instance.Achievement2)
        {
            Acieve2Pic.SetActive(true);
        }
    }

}
