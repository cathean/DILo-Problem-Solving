using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler4 : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 inputVector = Vector2.zero;

    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        MoveCircle(inputVector, speed);
    }

    private void MoveCircle(Vector2 input, float velocity)
    {
        rb2d.velocity = inputVector * velocity;
    }
}
