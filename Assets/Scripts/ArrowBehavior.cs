using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isStuck = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the arrow isn't already stuck to something
        if (!isStuck)
        {
            // The arrow hit something, make it a child of what it hit
            transform.parent = collision.transform;

            // Stop physics simulation on the arrow
            rb.simulated = false;

            // Optionally, you can also reset the velocity and angular velocity
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            // Set the isStuck flag so the arrow doesn't get stuck again
            isStuck = true;
        }
    }
}
