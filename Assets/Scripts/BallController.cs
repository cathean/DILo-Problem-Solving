using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        MoveCircle(speed);
    }
    
    private void MoveCircle(float velocity)
    {
        rb2d.velocity = Random.onUnitSphere * velocity;
    }
}
