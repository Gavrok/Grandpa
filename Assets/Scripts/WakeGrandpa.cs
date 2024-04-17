using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpGrandpa : MonoBehaviour
{
    public Animator animator;
    public string triggerName;
    public void SetTrigger()
    {
        if (animator != null && !string.IsNullOrEmpty(triggerName))
        {
            animator.SetTrigger(triggerName);
        }
    }
}
