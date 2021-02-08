using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MaxSpeed;
    [SerializeField] private float Acceleration;
    [SerializeField] private float Steering;

    private Rigidbody2D rb;

    private float x;
    private float y = 1;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");

        if(Input.GetAxis("Vertical") > 0.5f)
        {
            rb.drag = 0;
            Vector2 Speed = transform.up * (y * Acceleration);
            rb.AddForce(Speed);
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            rb.drag = 0;
            Vector2 Speed = transform.up * (y * Acceleration);
            rb.AddForce(-Speed * 0.9f);
        }
        else
        {
            rb.drag = 1;
        }

        float Direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));

        if(Acceleration > 0)
        {
            if (Direction > 0)
            {
                rb.rotation -= x * Steering * (rb.velocity.magnitude / MaxSpeed);
            }
            else
            {
                rb.rotation += x * Steering * (rb.velocity.magnitude / MaxSpeed);
            }
        }

        float DriftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;

        Vector2 RelativeForce = Vector2.right * DriftForce;

        rb.AddForce(rb.GetRelativeVector(RelativeForce));

        if(rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * MaxSpeed;
        }

        Debug.DrawLine(rb.position, rb.GetRelativePoint(RelativeForce), Color.red);       //Shows what the car is rotating around
    }
}
