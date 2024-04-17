using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnRadioScript : MonoBehaviour
{
    public RadioControl radioControl;
    private bool playerInside = false;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            TurnOnRadioScipt();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }


    void TurnOnRadioScipt()
    {
       
        bool shouldActivate = true;

        if (shouldActivate)
        {
            radioControl.isActive = true;
        }
        else
        {
            radioControl.isActive = false;
        }
    }
}
