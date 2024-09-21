using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float torqueForce = 12.5f;

    Rigidbody2D rigidBody2D;
    SurfaceEffector2D surfaceEffector2D;

    bool CanMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove == true)
        {
        RotatePlayer();
        IncreaseDecrease();
        }
    }

    public void DisableControls()
    {
        CanMove = false;
    }

    float BoostSpeed = 20f;
    float BaseSpeed = 15f;
    public void IncreaseDecrease()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = BoostSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = BaseSpeed;
        }
    }
    
    public void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody2D.AddTorque(torqueForce);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody2D.AddTorque(-torqueForce);
        }
    }
}