using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBehaviour : MonoBehaviour
{
    public bool grayscaleOnPause = false;
    public bool freezeLocOnPause = false;

    public Material grayscaleMaterial;

    private Renderer renderer;
    private Material normalMaterial;

    private Rigidbody2D rigidbody;

    private TimeStop timeStop;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            normalMaterial = renderer.material;
        }

        rigidbody = GetComponent<Rigidbody2D>();

        timeStop = ScriptableObject.CreateInstance<TimeStop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grayscaleOnPause && renderer != null)
        {
            // change material to grayscale if time is stopped
            renderer.material = timeStop.getIsTimeStopped() ? grayscaleMaterial : normalMaterial;
        }

        if (freezeLocOnPause && rigidbody != null)
        {
            rigidbody.constraints = timeStop.getIsTimeStopped() ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
