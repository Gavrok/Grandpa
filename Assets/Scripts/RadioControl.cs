using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RadioControl : MonoBehaviour
{
    [Header("Activation Control")]
    public bool isActive = true;

    [Header("Left Knob")]
    public Image LeftKnobImage;
    //public KeyCode rotateKeyLeft = KeyCode.Mouse0; 
    public float rotationSpeedLeft = 90f; 
    public bool Leftclockwise = true;

    [Header("Right Knob")]
    public Image RightKnobImage;
    //public KeyCode rotateKeyRight = KeyCode.Mouse1;
    public float rotationSpeedRight = 90f;
    public bool Rightclockwise = true;

    [Header("Radio Slider")]
    public Slider targetSlider;
    public float sliderSpeed = 0.5f;

    [Header("Station tunings")]
    public GameObject BoyScene;
    public bool TuneIntoBoy = true;
    public float boyStart = 0.087f;
    public float boyEnd = 0.33f;
    public GameObject ManLevel;
    public bool TuneIntoMan = true;
    public float manStart = 0.34f;
    public float manEnd = 0.66f;
    public GameObject GrandadLevel;
    public bool TuneIntoGrandad = true;
    public float grandadStart = 0.67f;
    public float grandadEnd = 1f;

    [Header("Target Player Script")]
    public EnhancedCharacterController2D characterController;

    [Header("Static 1 Fade")]
    public Image fadeImage;
    public float StaticInStart = 0.087f;
    public float StaticInEnd = 0.33f;
    public float StaticOutStart = 0.33f;
    public float StaticOutEnd = 0.33f;

    [Header("Static 2 Fade")]
    public Image fadeImage2;
    public float Static2InStart = 0.087f;
    public float Static2InEnd = 0.33f;
    public float Static2OutStart = 0.33f;
    public float Static2OutEnd = 0.33f;

    [Header("Levels and Tunage")]
    private List<Level> levels;



    /*    private void Start()
        {
            CheckActiveLevel();
        }*/

    private void Start()
    {
        InitializeLevels();
        //CheckActiveLevel();
        RecalculateTuningRanges();
        targetSlider.value += 0.01f;
        targetSlider.onValueChanged.Invoke(targetSlider.value);
    }

    void Update()
    {
        if (!isActive) return; //if not on, rest won't work

        if (Input.GetMouseButton(0))
        {
            KeyLeft();
        }
        
        if (Input.GetMouseButton(1))
        {
            KeyRight();
        }

        LevelTuneIn();
        UpdateFade(fadeImage, StaticInStart, StaticInEnd, StaticOutStart, StaticOutEnd);

        UpdateFade(fadeImage2, Static2InStart, Static2InEnd, Static2OutStart, Static2OutEnd);
    }

    //this is new
    private void InitializeLevels()
    {
        levels = new List<Level>
        {
            new Level(BoyScene, TuneIntoBoy),
            new Level(ManLevel, TuneIntoMan),
            new Level(GrandadLevel, TuneIntoGrandad),
        };
    }

    public void UpdateLevelAvailability()
    {
        levels[0].CanTuneTo = TuneIntoBoy;
        levels[1].CanTuneTo = TuneIntoMan;
        levels[2].CanTuneTo = TuneIntoGrandad;

        RecalculateTuningRanges();
    }

    public void RecalculateTuningRanges()
    {
        // Filter out levels that cannot be tuned into
        var activeLevels = levels.Where(level => level.CanTuneTo).ToList();

        // Calculate new tuning range for each active level
        float rangeSize = 1f / activeLevels.Count; // Divide the slider evenly among active levels

        for (int i = 0; i < activeLevels.Count; i++)
        {
            // Adjust start and end based on the new range size
            activeLevels[i].Start = i * rangeSize;
            activeLevels[i].End = (i + 1) * rangeSize;
        }
        Debug.Log("ReTune Ran");
    }
    //end this is new

/*    private void CheckActiveLevel()
    {
        DeactivateAllLevels();
        if (targetSlider.value >= boyStart && targetSlider.value <= boyEnd)
        {
            BoyScene.SetActive(true);
            Debug.Log("BoyLevel is initially active.");
        }
        else if (targetSlider.value > manStart && targetSlider.value <= manEnd)
        {
            ManLevel.SetActive(true);
            Debug.Log("ManLevel is initially active.");
        }
        else if (targetSlider.value > grandadStart && targetSlider.value <= grandadEnd)
        {
            GrandadLevel.SetActive(true);
            Debug.Log("GrandadLevel is initially active.");
        }
    }*/

    public void SetLevelAvailability(int levelIndex, bool available)
    {
        if (levelIndex >= 0 && levelIndex < levels.Count)
        {
            levels[levelIndex].CanTuneTo = available;
            RecalculateTuningRanges();
        }
    }

    private void DeactivateAllLevels()
    {
        BoyScene.SetActive(false);
        ManLevel.SetActive(false);
        GrandadLevel.SetActive(false);
    }
    private void KeyLeft()
    {
            float direction = Leftclockwise ? -1f : 1f;
            float rotationAmount = rotationSpeedLeft * Time.deltaTime * direction;
            LeftKnobImage.transform.Rotate(0f, 0f, rotationAmount);
            //slider
            float sliderMovement = sliderSpeed * Time.deltaTime * direction;
            targetSlider.value -= sliderMovement;
    }

    private void KeyRight()
    {
            float direction = Rightclockwise ? -1f : 1f;
            float rotationAmount = rotationSpeedRight * Time.deltaTime * direction;
            RightKnobImage.transform.Rotate(0f, 0f, rotationAmount);
            float sliderMovement = sliderSpeed * Time.deltaTime * direction;
            targetSlider.value -= sliderMovement;
    }

    /*    private void LevelTuneIn()
        {

            // sets the levels
            BoyScene.SetActive(false);
            ManLevel.SetActive(false);
            GrandadLevel.SetActive(false);

            // sets the player state
            characterController.enableState1 = false;
            characterController.enableState2 = false;
            characterController.enableState3 = false;


            // Activate objects based on the slider's current value and defined areas
            if (targetSlider.value >= boyStart && targetSlider.value <= boyEnd && TuneIntoBoy)
            {
                BoyScene.SetActive(true);
                characterController.enableState1 = true;
            }
            else if (targetSlider.value > manStart && targetSlider.value <= manEnd && TuneIntoMan)
            {
                ManLevel.SetActive(true);
                characterController.enableState2 = true;
            }
            else if (targetSlider.value > grandadStart && targetSlider.value <= grandadEnd && TuneIntoGrandad)
            {
                GrandadLevel.SetActive(true);
                characterController.enableState3 = true;
            }
            characterController.UpdateStateObjects();
        }*/
    private void LevelTuneIn()
    {
        DeactivateAllLevels(); // Ensure all levels are initially deactivated

        // sets the player state
        characterController.enableState1 = false;
        characterController.enableState2 = false;
        characterController.enableState3 = false;

        
        foreach (var level in levels)
        {
            // Check if the current slider value is within the level's range and if it's tunable
            if (targetSlider.value >= level.Start && targetSlider.value <= level.End && level.CanTuneTo)
            {
                level.Scene.SetActive(true);

                // Example of setting player state based on the active level
                // You'll need to adjust this to fit your actual gameplay logic
                if (level.Scene == BoyScene)
                {
                    characterController.enableState1 = true;
                }
                else if (level.Scene == ManLevel)
                {
                    characterController.enableState2 = true;
                }
                else if (level.Scene == GrandadLevel)
                {
                    characterController.enableState3 = true;
                }

                break; // Exit the loop since we found the active level
            }
        }

        characterController.UpdateStateObjects(); // Update player states based on the active level
    }


    private void UpdateFade(Image image, float inStart, float inEnd, float outStart, float outEnd)
    {
        float alpha = 1.0f;

        if (targetSlider.value >= inStart && targetSlider.value <= inEnd)
        {
            float progress = (targetSlider.value - inStart) / (inEnd - inStart);
            alpha = Mathf.Lerp(0f, 1f, progress);
        }
        else if (targetSlider.value >= outStart && targetSlider.value <= outEnd)
        {
            float progress = (targetSlider.value - outStart) / (outEnd - outStart);
            alpha = Mathf.Lerp(1f, 0f, progress);
        }
        else if (targetSlider.value < inStart || targetSlider.value > outEnd)
        {
            alpha = 0f;
        }

        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }


}

//class for new stuff

public class Level
{
    public GameObject Scene;
    public bool CanTuneTo;
    public float Start;
    public float End;

    public Level(GameObject scene, bool canTuneTo)
    {
        Scene = scene;
        CanTuneTo = canTuneTo;
        Start = 0f; // Initial value, will be recalculated
        End = 0f;   // Initial value, will be recalculated
    }
}
