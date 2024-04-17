using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class FMODSliderTrigger : MonoBehaviour
{
    public Slider slider;
    [field: SerializeField] public EventReference radioFMOD { get; private set; }
    public string parameterName = "RadioTuner"; //FMOD parameter

    private FMOD.Studio.EventInstance eventInstance;

    void Start()
    {
        eventInstance = RuntimeManager.CreateInstance(radioFMOD);

        eventInstance.start();

        slider.onValueChanged.AddListener(HandleSliderChange);
    }

    void HandleSliderChange(float value)
    {
        // Update the FMOD parameter based on the slider's value
        eventInstance.setParameterByName(parameterName, value);
    }

    void OnDestroy()
    {
        // Stop and release the FMOD event when the object is destroyed
        eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        eventInstance.release();
    }
}
