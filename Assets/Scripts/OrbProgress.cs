using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbProgress : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            transform.Rotate(0, 180, 0);
        }
        
    }
}
