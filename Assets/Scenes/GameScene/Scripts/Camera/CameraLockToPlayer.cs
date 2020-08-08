using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockToPlayer : MonoBehaviour
{
    GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3
            (
                playerGameObject.transform.position.x,
                playerGameObject.transform.position.y,
                -10
            );
    }
}
