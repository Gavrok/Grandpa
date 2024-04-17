using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementChecks : MonoBehaviour
{
    public enum AchievementToCheck { Achievement1, Achievement2, Achievement3 }
    public AchievementToCheck achievementToCheck;
    public GameObject objectToControl;

    private void Update()
    {
        if (GameManagerBools.Instance != null && objectToControl != null)
        {
            switch (achievementToCheck)
            {
                case AchievementToCheck.Achievement1:
                    objectToControl.SetActive(GameManagerBools.Instance.Achievement1);
                    break;
                case AchievementToCheck.Achievement2:
                    objectToControl.SetActive(GameManagerBools.Instance.Achievement2);
                    break;
                case AchievementToCheck.Achievement3:
                    objectToControl.SetActive(GameManagerBools.Instance.Achievement3);
                    break;
            }
        }
    }
}
