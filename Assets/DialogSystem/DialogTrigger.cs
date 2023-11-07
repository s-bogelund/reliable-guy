using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog[] Dialogs;

    public void TriggerDialog()
    {
        foreach (Dialog dialog in Dialogs)
        {
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
        if (collision != null)
        {
        
            if (collision.CompareTag("Player"))
            {
                Debug.Log(Dialogs[0].name);
                foreach (Dialog dialog in Dialogs)
                {
                    FindObjectOfType<DialogManager>().StartDialog(dialog);
                }
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogError("Collision object is null. Make sure it's properly initialized.");
        }
    }
}
