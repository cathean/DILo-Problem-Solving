using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Spaceship Settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30f;
    public float turnFactor = 3.5f;
    public float dragForce = 3f;
    public float minSpeedFactor = 8f;
    public float maxSpeed = 20f;
    public float reverseMaxFactor = 0.5f;

    public float VelocityUp { get; set; }

    private float accelerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle = 0;
    private Vector2 inputVector = Vector2.zero;

    // Components
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        SetInputVector(inputVector);
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Resource")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.OnGetStar.Invoke();
        }
        else if(collision.tag == "Enemy")
        {
            GameManager.Instance.OnHitMeteor.Invoke();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void ApplyEngineForce()
    {
        VelocityUp = Vector2.Dot(transform.up, rb2d.velocity);

        // Limit max forward speed
        if (VelocityUp > maxSpeed && accelerationInput > 0)
            return;

        // Limit max reverse speed
        if (VelocityUp < -maxSpeed * reverseMaxFactor && accelerationInput < 0)
            return;

        // Apply drag if there's no input
        if (accelerationInput == 0)
            rb2d.drag = Mathf.Lerp(rb2d.drag, dragForce, Time.fixedDeltaTime * dragForce);
        else
            rb2d.drag = 0;

        Vector2 engineForce = transform.up * accelerationInput * accelerationFactor;

        rb2d.AddForce(engineForce, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        // Limit cars ability to turn when moving slowly
        float minSpeed = rb2d.velocity.magnitude / minSpeedFactor;
        minSpeed = Mathf.Clamp01(minSpeed);

        rotationAngle -= steeringInput * turnFactor * minSpeed;

        rb2d.MoveRotation(rotationAngle);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb2d.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb2d.velocity, transform.right);

        rb2d.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
