using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;

    // Define the Y position where you want the sprite to stop
    public float lockedYPosition = 1.0f;  // Adjust this to match the bottom of the TopPanel

    void Start()
    {
        // Get the Rigidbody2D component attached to the Person
        rb = GetComponent<Rigidbody2D>();
    }

    // Detect collision with the boundary panel
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we collided with is the panel boundary (using a tag)
        if (collision.gameObject.tag == "PanelBoundary")
        {
            // Stop the Y movement by setting the gravity scale to 0 to prevent falling
            rb.gravityScale = 0f;

            // Optionally, lock the Y position to prevent further movement
            transform.position = new Vector3(transform.position.x, lockedYPosition, transform.position.z);
        }
    }

    // Reset gravity when the person is no longer colliding with the boundary (optional)
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PanelBoundary")
        {
            // Restore gravity when the person is no longer colliding with the boundary
            rb.gravityScale = 1f;  // Reset gravity scale to normal if you want the person to fall again
        }
    }
}