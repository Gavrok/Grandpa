using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWalking : MonoBehaviour
{
    public EnhancedCharacterController2D PlayerControl;

    public void EnableScript()
    {
        if (PlayerControl != null)
        {
            PlayerControl.enabled = true;
        }
    }

    public void DisableScript()
    {
        if (PlayerControl != null)
        {
            PlayerControl.enabled = false;
        }
    }
}
