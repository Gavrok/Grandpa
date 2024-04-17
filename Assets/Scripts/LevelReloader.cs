using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    public PlayerPos PlayerReset;
    public DementiaLevel DementiaRise;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DementiaRise.IncrementStage();
            ResetPlayerPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ResetToCP"))
        {
            //ReloadCurrentLevel();
            DementiaRise.IncrementStage();
            ResetPlayerPosition();
            Debug.Log("Level reloaded");

        }
    }

    void ReloadCurrentLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

    }

    void ResetPlayerPosition()
    {

        if (PlayerReset == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerReset = player.GetComponent<PlayerPos>();
            }
        }

        if (PlayerReset != null)
        {
            PlayerReset.MoveToLastCheckpoint();
        }
        else
        {
            Debug.LogError("PlayerPos component not found on the player.");
        }
    }
}
