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

    private BoxCollider2D boxCollider;

    private Vector2 velocity;

    private bool grounded; // SET GROUNDED TO TRUE WHEN IT COLLIDES WITH FLOOR

    public Vector3 direction;

    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update() {
        // Jumping
        if (grounded) {
            velocity.y = 0;
            if (Input.GetButtonDown("Jump")) {
                // Calculate the velocity required to achieve the target jump height
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        // Moving left/right
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0) {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        // flips based on your velocity
        if (velocity.x > 0)
        {
            direction = Vector3.right;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (velocity.x < 0) // specifically do nothing when x = 0
        {
            direction = Vector3.left;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime);
        grounded = false;

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits) {
            if (hit == boxCollider) {
                continue;
            }

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
            if (colliderDistance.isOverlapped) {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                // If intersect an object beneath us 
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0) {
                    grounded = true;
                }
            }
        }
    }
}
