using UnityEngine;

public class FadeObjectBasedOnStage : MonoBehaviour
{
    public DementiaLevel stageManager; // Reference to the StageManager script
    private SpriteRenderer spriteRenderer;

    public float maxAlpha = 1f; // Maximum alpha value (fully opaque)
    public float minAlpha = 0f; // Minimum alpha value (fully transparent)
    public int fadeInStartStage = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (stageManager == null || spriteRenderer == null) return;

        if (stageManager.currentStage >= fadeInStartStage)
        {
            // Calculate the progress relative to the final stage, adjusted for the start stage
            float progress = (stageManager.currentStage - fadeInStartStage) / (float)(stageManager.finalStage - fadeInStartStage);
            progress = Mathf.Clamp(progress, 0f, 1f); // Ensure progress stays within 0 and 1

            // Calculate the new alpha based on progress
            float newAlpha = Mathf.Lerp(minAlpha, maxAlpha, progress);

            // Set the new alpha value
            Color newColor = spriteRenderer.color;
            newColor.a = newAlpha;
            spriteRenderer.color = newColor;
        }
    }
}
