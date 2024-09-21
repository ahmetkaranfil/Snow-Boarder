using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDedector : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    SurfaceEffector2D surfaceEffector2D;
    
    float sceneDelay = 0.75f;
    float reducedSpeed = 2.50f;
    
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip CrashSFX;

    bool onceDeath = false;

    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }  
 
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && circleCollider2D.IsTouching(other.collider) && onceDeath == false)
        {
            onceDeath = true;
            Debug.Log("Ouch! Hit my Head!");
            FindObjectOfType<PlayerController>().DisableControls();
            surfaceEffector2D.speed = reducedSpeed;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(CrashSFX);
            Invoke("ReloadScene", sceneDelay);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}