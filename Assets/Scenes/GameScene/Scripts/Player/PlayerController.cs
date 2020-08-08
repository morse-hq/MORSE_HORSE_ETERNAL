using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    private Rigidbody2D rigidbody;

    private bool grounded; // SET GROUNDED TO TRUE WHEN IT COLLIDES WITH FLOOR

    public Vector3 direction;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        pointInDirection(Vector3.right);
    }

    void Update() {
        Vector2 velocity = rigidbody.velocity;

        // Jumping
        if (grounded)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                // Calculate the velocity required to achieve the target jump height
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
                grounded = false;
            }
        }

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        // Moving left/right
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0) {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * horizontalInput, acceleration * Time.deltaTime);
        } else {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        // flips based on your velocity
        if (velocity.x > 0) {
            pointInDirection(Vector3.right);
        } else if (velocity.x < 0) { // specifically do nothing when x = 0
            pointInDirection(Vector3.left);
        }

        rigidbody.velocity = velocity;
    }

    private void pointInDirection(Vector3 newDirection)
    {
        direction = newDirection;
        GetComponent<SpriteRenderer>().flipX = newDirection == Vector3.right; // flip if you wanna face right
    }

    // there's a trigger on your feet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }
}
