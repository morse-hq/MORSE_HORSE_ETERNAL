using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNyoom : MonoBehaviour
{
    public Vector3 direction;

    public int bulletSpeed = 5;

    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = direction * bulletSpeed;
    }
}
