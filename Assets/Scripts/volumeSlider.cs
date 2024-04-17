using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        MASTER,

        MUSIC,

        SFX,

    }

    [Header("Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider volSlider;

    private void Awake()
    {
        volSlider = this.GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                volSlider.value = AudioManager.Instance.masterVolume;
                break;
            case VolumeType.MUSIC:
                volSlider.value = AudioManager.Instance.musicVolume;
                break;
            case VolumeType.SFX:
                volSlider.value = AudioManager.Instance.SFXVolume;
                break;
            default:
                Debug.Log("Volume type not supported: " + volumeType);
                break;
        }
    }

    public void OnSLiderValueChange()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                AudioManager.Instance.masterVolume = volSlider.value;
                break;
            case VolumeType.MUSIC:
                AudioManager.Instance.musicVolume = volSlider.value;
                break;
            case VolumeType.SFX:
                AudioManager.Instance.SFXVolume = volSlider.value;
                break;
            default:
                Debug.Log("Volume type not supported: " + volumeType);
                break;
        }

    }
}
