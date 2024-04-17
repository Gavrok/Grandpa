using UnityEngine;

public class DisappearOnHit : MonoBehaviour
{
    public GameObject UIImagePart;
    public bool activateUiImagePart = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            UIImagePart.SetActive(activateUiImagePart);

            HUDManager.instance.IncreaseScore(1);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            UIImagePart.SetActive(activateUiImagePart);
            //UIImagePart.SetActive(true);
            HUDManager.instance.IncreaseScore(1);
            //fmod sound

        }
    }
}
