using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeSwapper : MonoBehaviour
{
    TimeStop timeStop;

    // Start is called before the first frame update
    void Start()
    {
        timeStop = ScriptableObject.CreateInstance<TimeStop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeStop.toggleTimeStopped();
        }
    }
}
