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

    private Collider2D boxCollider;

    private Rigidbody2D rigidbody;

    private Vector2 velocity;

    private bool grounded; // SET GROUNDED TO TRUE WHEN IT COLLIDES WITH FLOOR

    public Vector3 direction;

    void Start() {
        boxCollider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        pointInDirection(Vector3.right);
    }

    void Update() {
        // // Jumping
        // if (grounded) {
        //     velocity.y = 0;
        //     if (Input.GetButtonDown("Jump")) {
        //         // Calculate the velocity required to achieve the target jump height
        //         velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
        //     }
        // }

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        // Jumping
        float verticalInput = Input.GetAxisRaw("Jump");
        if (velocity.y == 0) {
            // Calculate the velocity required to achieve the target jump height
            velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
        }

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

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        Debug.Log(velocity.y);
        rigidbody.velocity = velocity;

        grounded = false;
    }

    private void pointInDirection(Vector3 newDirection)
    {
        direction = newDirection;
        GetComponent<SpriteRenderer>().flipX = newDirection == Vector3.right; // flip if you wanna face right
    }
}
