using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayToReloadSeconds = 1f;
    [SerializeField] ParticleSystem crashEffect;
    CircleCollider2D head;
    [SerializeField] AudioClip crashSFX;

    [SerializeField] PlayerController playerController;


    bool hasCrashed = false;
    void Start()
    {
        head = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hasCrashed && other.collider.tag == "Ground" && head.IsTouching(other.collider))
        {
            hasCrashed = true;
            
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke(nameof(ReloadScene), delayToReloadSeconds);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
