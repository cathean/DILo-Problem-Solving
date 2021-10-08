using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;

    //Components
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetVelocity(speed);
    }
    
    void FixedUpdate()
    {
        
    }

    private void SetVelocity(float velocity)
    {
        rb2d.velocity = Random.onUnitSphere * velocity;
    }
}
