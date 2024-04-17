using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class MortarRound : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    public GameObject ExplosionCollider;
    [SerializeField] private EventReference MortarHitSound;


    void Awake()
    {
        //explosionEffect = GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            explosionEffect.Play(); // Play the explosion effect
            //AudioManager.Instance.PlayOneSHot(MortarHitSound, this.transform.position);
            GetComponent<SpriteRenderer>().enabled = false; // Optionally hide the bomb sprite
            GetComponent<Collider2D>().enabled = false; // Disable collider to prevent multiple triggers
            ExplosionCollider.SetActive(true);

            // Optionally destroy the bomb after the particles have finished
            Destroy(gameObject, explosionEffect.main.duration);
        }
        if (other.CompareTag("Player"))
        {
            explosionEffect.Play(); // Play the explosion effect
            //ReloadCurrentLevel();
            GetComponent<SpriteRenderer>().enabled = false; // Optionally hide the bomb sprite
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, explosionEffect.main.duration);
        }
    }

    void ReloadCurrentLevel()
    {
        // Get the current scene name
        string sceneName = SceneManager.GetActiveScene().name;

        // Load the current scene
        SceneManager.LoadScene(sceneName);
    }

}
