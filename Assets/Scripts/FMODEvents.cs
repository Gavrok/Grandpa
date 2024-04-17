using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    /*[field: Header("Home Ambience")]
    [field: SerializeField] public EventReference grandpaHome { get; private set; }

    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference grandpaFoot { get; private set; }

    [field: Header("Memory SFX")]
    [field: SerializeField] public EventReference memoryCollected { get; private set; }*/

    [field: Header("Bird Intro Sound")]
    [field: SerializeField] public EventReference BirdIntro { get; private set; }

    public static FMODEvents Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene");
        }
        Instance = this;
    }
}
