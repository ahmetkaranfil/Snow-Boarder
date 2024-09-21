using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    float sceneDelay = 1.25f;
    AudioSource audioSource;
    [SerializeField] ParticleSystem finishEffect;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
        Debug.Log("I'm Finished!");
        finishEffect.Play();
        audioSource.Play();
        Invoke("ReloadScene", sceneDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}