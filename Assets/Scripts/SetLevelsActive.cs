using UnityEngine;

public class SetLevelsActive : MonoBehaviour
{
    public RadioControl radioControl; // Assign this via the Inspector

    // These public booleans allow you to set the desired state for each level directly in the Inspector.
    [Header("Enter Disable Levels")]
    public bool BoyLevel = false;
    public bool ManLevel = false;
    public bool GrandadLevel = false;

    [Header("Exit Set Levels")]
    public bool BoyLevelExit = false;
    public bool ManLevelExit = false;
    public bool GrandadLevelExit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider is the player or whatever criteria you want
        //if (collision.CompareTag("Player")) // Ensure your player GameObject has the "Player" tag
        //{
        // Directly set the levels' availability based on the Inspector settings
            Debug.Log("Something entered the trigger: " + collision.gameObject.name);
            radioControl.TuneIntoBoy = BoyLevel;
            radioControl.TuneIntoMan = ManLevel;
            radioControl.TuneIntoGrandad = GrandadLevel;

            // Since the script directly sets the availability, it should call the update method
            // to adjust the game state accordingly.
            radioControl.RecalculateTuningRanges();
            radioControl.UpdateLevelAvailability();
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collider is the player or whatever criteria you want
        //if (collision.CompareTag("Player")) // Ensure your player GameObject has the "Player" tag
        //{
        // Directly set the levels' availability based on the Inspector settings
        Debug.Log("Something entered the trigger: " + collision.gameObject.name);
        radioControl.TuneIntoBoy = BoyLevelExit;
        radioControl.TuneIntoMan = ManLevelExit;
        radioControl.TuneIntoGrandad = GrandadLevelExit;

        // Since the script directly sets the availability, it should call the update method
        // to adjust the game state accordingly.
        radioControl.RecalculateTuningRanges();
        radioControl.UpdateLevelAvailability();
        //}
    }
}