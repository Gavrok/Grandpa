using UnityEngine;

public class DementiaLevel : MonoBehaviour
{
    public int currentStage = 0;
    public int finalStage = 10;

    public void IncrementStage()
    {
        if (currentStage < finalStage)
        {
            currentStage++;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            IncrementStage();
        }
    }
}
