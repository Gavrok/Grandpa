using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public GameObject OptionsMenu;
    public EnhancedCharacterController2D PlayerController;
    public RadioControl RadioController;
    private bool IsOptionsOpen = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsOptionsOpen)
            {
                OptionsMenuOpen();
            }
            
        }
    }

    public void OptionsMenuOpen()
    {
        Cursor.visible = !Cursor.visible;

            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.None;
            }

        OptionsMenu.SetActive(true);
        PlayerController.isActive = false;
        RadioController.enabled = false;
        IsOptionsOpen = true;

    }

    public void CloseOptionMenu()
    {
        OptionsMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerController.isActive = true;
        RadioController.enabled = true;
        IsOptionsOpen = false;
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void HideCursor()
    {
        Cursor.visible = !Cursor.visible;

        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
