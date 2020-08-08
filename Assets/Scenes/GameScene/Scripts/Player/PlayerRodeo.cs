using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRodeo : MonoBehaviour
{
    private GameObject ridingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ridingObject != null && ridingObject.GetComponent<Rigidbody2D>() != null)
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
        ridingObject = null;
    }
}
