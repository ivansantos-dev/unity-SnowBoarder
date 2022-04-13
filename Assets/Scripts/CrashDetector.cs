using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{

    [SerializeField] float delayToReloadSeconds = 1f;
    [SerializeField] ParticleSystem crashEffect;

    CircleCollider2D head;

    void Start()
    {
        head = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground" && head.IsTouching(other.collider))
        {
            crashEffect.Play();
            Invoke(nameof(ReloadScene), delayToReloadSeconds);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
