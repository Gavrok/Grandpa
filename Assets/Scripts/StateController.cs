using UnityEngine;

public class StateController : MonoBehaviour
{
    public GameObject boySpecific;
    public GameObject manSpecific;
    public GameObject grandpaSpecific;
    public EnhancedCharacterController2D PlayerControls;

    void Update()
    {
        UpdateGameObjectsState();
    }

    void UpdateGameObjectsState()
    {
        if (boySpecific != null) boySpecific.SetActive(PlayerControls.enableState1);
        if (manSpecific != null) manSpecific.SetActive(PlayerControls.enableState2);
        if (grandpaSpecific != null) grandpaSpecific.SetActive(PlayerControls.enableState3);
    }
}
