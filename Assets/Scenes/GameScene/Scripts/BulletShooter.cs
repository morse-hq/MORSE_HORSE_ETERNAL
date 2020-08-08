using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletShooter : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            Vector3 myDirection = GetComponent<PlayerController>().direction;
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = this.transform.position;
            bulletObject.transform.position += myDirection;
            bulletObject.GetComponent<BulletNyoom>().direction = myDirection; // pass direction to bulletnyoom
        }
    }
}
