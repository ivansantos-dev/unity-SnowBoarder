using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayToReloadSeconds = 1f;
    [SerializeField] ParticleSystem finishEffect;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();
            Invoke(nameof(ReloadScene), delayToReloadSeconds);
        }
    }

    void ReloadScene() {
            SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
}
