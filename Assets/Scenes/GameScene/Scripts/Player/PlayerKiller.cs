using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    public void killPlayer()
    {
        Destroy(this.gameObject);
    }
}
