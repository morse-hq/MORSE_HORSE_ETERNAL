using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    LineRenderer lineRenderer;
    ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = transform.GetComponentInChildren<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(0,0,1)); // first point is my position

        particleSystem = transform.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 100f);
        Vector3 relativeHitPosition = transform.position - (Vector3)hit.point;
        lineRenderer.SetPosition(1, relativeHitPosition);

        particleSystem.transform.position = hit.point;

        if (hit.collider.gameObject.name.Equals("Player"))
        {
            hit.collider.gameObject.GetComponent<PlayerKiller>().killPlayer();
        }
    }
}
