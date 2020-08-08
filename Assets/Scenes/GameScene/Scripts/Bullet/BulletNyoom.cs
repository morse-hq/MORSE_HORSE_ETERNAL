using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNyoom : MonoBehaviour
{
    public Vector2 direction;

    public int bulletSpeed = 5;

    private Rigidbody2D myRigidBody;

    private TimeStop timeStop;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        timeStop = ScriptableObject.CreateInstance<TimeStop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeStop.getIsTimeStopped())
        {
            myRigidBody.velocity = direction * bulletSpeed;
        }
    }
}
