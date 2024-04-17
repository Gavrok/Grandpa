using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBools : MonoBehaviour
{
    public static GameManagerBools Instance;

    public bool Achievement1;
    public bool Achievement2;
    public bool Achievement3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void Achievement1Bool(bool value)
    {
        Achievement1 = value;
    }

    public void Achievement2Bool(bool value)
    {
        Achievement2 = value;
    }

    public void Achievement3Bool(bool value)
    {
        Achievement3 = value;
    }
}
