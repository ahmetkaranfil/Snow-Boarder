using UnityEngine;

public class FrictionTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem frictionEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            frictionEffect.Play();
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            frictionEffect.Stop();
        }
    }
}
