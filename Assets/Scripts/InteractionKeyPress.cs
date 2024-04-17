using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionKey : MonoBehaviour
{
    public GameObject objectToActivate;
    private bool playerInside = false;
    public EnhancedCharacterController2D PlayerControl;
    public bool canToggle = true;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (canToggle)
            {
                objectToActivate.SetActive(!objectToActivate.activeSelf);
                TurnOnOffPlayerControl();
            }
            else
            {
                objectToActivate.SetActive(!objectToActivate.activeSelf);
            }



        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void TurnOnOffPlayerControl()
    {

        /* bool shouldActivate = true;

         if (shouldActivate)
         {
             PlayerControl.isActive = true;
         }
         else
         {
             PlayerControl.isActive = false;
         }*/
        PlayerControl.isActive = !PlayerControl.isActive;
    }
}
