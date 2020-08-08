using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = transform.GetComponentInChildren<LineRenderer>();
        Vector3[] tempVectors = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(tempVectors);
        foreach (Vector3 vector in tempVectors)
        {
            Debug.Log(vector);
        }
        lineRenderer.SetPositions(new Vector3[2]); // initilise with two empty point
        lineRenderer.SetPosition(0, new Vector3(0,0,1)); // first point is my position
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 100f);
        lineRenderer.SetPosition(1, transform.position - (Vector3)hit.point);
        Debug.Log("START");
        Debug.Log(hit.point);
        Debug.Log(transform.position);
        Debug.Log(transform.position - (Vector3)hit.point);
    }
}
