using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBehaviour : MonoBehaviour
{
    public bool grayscaleOnPause = false;

    public Material grayscaleMaterial;

    private Material normalMaterial;
    private Renderer renderer;
    private TimeStop timeStop;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            normalMaterial = renderer.material;
        }
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
    }
}
