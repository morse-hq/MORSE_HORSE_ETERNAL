using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRodeo : MonoBehaviour
{
    private GameObject ridingObject;
    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ridingObject != null && ridingObjectRigidBody() != null)
        {
            Debug.Log(ridingObject);
            transform.position += (Vector3)ridingObject.GetComponent<Rigidbody2D>().velocity * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ridingObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ridingObject != null && ridingObjectRigidBody() != null)
        {
            // transfer x momentum across 
            myRigidbody.velocity = new Vector2(
                ridingObjectRigidBody().velocity.x,
                myRigidbody.velocity.y
            );
        }

        ridingObject = null;
    }

    private Rigidbody2D ridingObjectRigidBody()
    {
        Rigidbody2D foundRigidBody = null;
        ridingObject.TryGetComponent<Rigidbody2D>(out foundRigidBody);
        return foundRigidBody;
    }
}
