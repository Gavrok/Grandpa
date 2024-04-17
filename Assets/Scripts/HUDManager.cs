using UnityEngine;
using TMPro; // Updated namespace for TextMeshPro

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    public TMP_Text scoreText;
    public GameObject[] objectsToShow;
    public int targetScore = 10;

    private int score = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();

        if (score >= targetScore)
        {
            foreach (GameObject obj in objectsToShow)
            {
                obj.SetActive(true);
            }
            //add fmod sound here
        }
    }
}
