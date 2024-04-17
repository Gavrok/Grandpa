using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioOnorOff : MonoBehaviour
{
    public RadioControl radioControl;
    public Animator radioAnimator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            radioControl.isActive = false;
            radioAnimator.SetTrigger("hideRadio");
            //add fmod static sound
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            radioControl.isActive = true;
            radioAnimator.SetTrigger("showRadio");

        }
    }

}
