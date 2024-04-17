using TMPro;
using UnityEngine;

public class JumbleText : MonoBehaviour
{
    public DementiaLevel stageManager;
    private TextMeshPro textMesh;

    public int startJumblingStage = 1; // The stage at which jumbling starts
    public int transitionStage = 5; // Stage at which we switch from jumbling words to jumbling letters
    private string originalText;
    private int lastJumbleStage = -1; // Track the last stage at which we jumbled the text

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        if (textMesh != null)
        {
            originalText = textMesh.text;
        }
    }

    void Update()
    {
        if (stageManager == null || textMesh == null) return;

        // Only jumble the text if the stage has changed since the last update
        // and the current stage is greater than or equal to startJumblingStage
        if (lastJumbleStage != stageManager.currentStage && stageManager.currentStage >= startJumblingStage)
        {
            JumbleTextBasedOnStage(stageManager.currentStage);
            lastJumbleStage = stageManager.currentStage;
        }
    }

    void JumbleTextBasedOnStage(int stage)
    {
        if (stage < transitionStage)
        {
            // In the initial stages, shuffle words
            JumbleWords();
        }
        else
        {
            // After the transition stage, shuffle letters within the words
            JumbleLetters();
        }
    }

    void JumbleWords()
    {
        string[] words = originalText.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            int swapIndex = Random.Range(0, words.Length);
            string temp = words[i];
            words[i] = words[swapIndex];
            words[swapIndex] = temp;
        }
        textMesh.text = string.Join(" ", words);
    }

    void JumbleLetters()
    {
        char[] letters = originalText.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            int swapIndex = Random.Range(0, letters.Length);
            char temp = letters[i];
            letters[i] = letters[swapIndex];
            letters[swapIndex] = temp;
        }
        textMesh.text = new string(letters);
    }
}