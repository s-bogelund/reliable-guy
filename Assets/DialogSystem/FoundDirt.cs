using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundDirt : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
           
        }

        else
        {
            Debug.LogError("Collision object is null. Make sure it's properly initialized.");
        }
    }
}
