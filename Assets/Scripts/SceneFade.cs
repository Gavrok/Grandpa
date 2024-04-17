using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public bool startSceneFadeIn = true;

    private void Start()
    {
        if (!startSceneFadeIn)
        {
            StartCoroutine(FadeIn());
        }
        
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float time = fadeDuration;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            float a = time / fadeDuration;
            fadeImage.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }

    IEnumerator FadeOut(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float a = time / fadeDuration;
            fadeImage.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
