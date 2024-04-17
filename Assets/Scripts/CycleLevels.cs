using UnityEngine;

public class CycleObjects : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    void Update()
    {
        // Activate object1 and deactivate object2 and object3 with key 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            object1.SetActive(true);
            object2.SetActive(false);
            object3.SetActive(false);
        }

        // Activate object2 and deactivate object1 and object3 with key 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            object1.SetActive(false);
            object2.SetActive(true);
            object3.SetActive(false);
        }

        // Activate object3 and deactivate object1 and object2 with key 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(true);
        }
    }
}
