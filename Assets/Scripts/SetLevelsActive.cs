using UnityEngine;

public class SetLevelsActive : MonoBehaviour
{
    public RadioControl radioControl; // Assign this via the Inspector


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
        // Check if the collider is the player
        //if (collision.CompareTag("Player")) // Ensure player GameObject has the "Player" tag
        //{
            Debug.Log("Something entered the trigger: " + collision.gameObject.name);
            radioControl.TuneIntoBoy = BoyLevel;
            radioControl.TuneIntoMan = ManLevel;
            radioControl.TuneIntoGrandad = GrandadLevel;

            // adjust the game state accordingly.
            radioControl.RecalculateTuningRanges();
            radioControl.UpdateLevelAvailability();
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player")) // Ensure player GameObject has the "Player" tag
        //{
        // Directly set the levels' availability based on the Inspector settings
        Debug.Log("Something entered the trigger: " + collision.gameObject.name);
        radioControl.TuneIntoBoy = BoyLevelExit;
        radioControl.TuneIntoMan = ManLevelExit;
        radioControl.TuneIntoGrandad = GrandadLevelExit;

        // adjust the game state accordingly.
        radioControl.RecalculateTuningRanges();
        radioControl.UpdateLevelAvailability();
        //}
    }
}