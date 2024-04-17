using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievmentUnlocks : MonoBehaviour
{
    public enum AchievementType { Achievement1, Achievement2, Achievement3 }
    public AchievementType achievementToSet;
    public GameObject AchieveUI;
    public GameObject memoryUnlockedPopUpUI;
    


    private void SetAchievement()
    {
        AchieveUI.SetActive(true);
        switch (achievementToSet)
        {
            case AchievementType.Achievement1:
                GameManagerBools.Instance.Achievement1Bool(true);
                break;
            case AchievementType.Achievement2:
                GameManagerBools.Instance.Achievement2Bool(true);
                break;
            case AchievementType.Achievement3:
                GameManagerBools.Instance.Achievement3Bool(true);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            SetAchievement();
            memoryUnlockedPopUpUI.SetActive(true);
            gameObject.SetActive(false);
            //fmod sound paper
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            SetAchievement();
            memoryUnlockedPopUpUI.SetActive(true);
            gameObject.SetActive(false);
            // add in ui stuff
            //fmod sound paper
        }
    }




}
