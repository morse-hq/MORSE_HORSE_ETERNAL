using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public int parallaxPercent = 50;

    public int someotherInt;

    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerGameObject != null)
        {
            float parallax = (float)parallaxPercent / 100;

            Debug.Log(parallax);

            transform.position = playerGameObject.transform.position * parallax;
        }
    }
}
