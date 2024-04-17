using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpTimerMe : MonoBehaviour
{
    public float displayDuration = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        MemoryUnlocked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MemoryUnlocked()
    {
        StartCoroutine(showPopUp());
    }

    private IEnumerator showPopUp()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        gameObject.SetActive(false);
    }
}
