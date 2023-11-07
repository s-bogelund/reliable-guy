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
            Dialog dialog = new Dialog("Player", new string[] {
                "I found some dirt!",
                "I should bring it to the scientist."
            });
            if (collision.CompareTag("Player"))
            {
                Debug.Log(dialog.name);
                FindObjectOfType<DialogManager>().StartDialog(dialog);
                Destroy(gameObject);
            }
        }

        else
        {
            Debug.LogError("Collision object is null. Make sure it's properly initialized.");
        }
    }
}
