using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog[] Dialogs;
    DialogManager _dialogManager ;

    private void Start()
    {
        _dialogManager = FindObjectOfType<DialogManager>();
    }
    public void TriggerDialog()
    {
        foreach (Dialog dialog in Dialogs)
        {
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }

    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
        
            if (collision.CompareTag("Player"))
            {
                Debug.Log(Dialogs[0].name);
                if(gameObject.name == "TownNarratorReturns" && !GameManager.Instance.isFirstRun)
                {
                    return;
                }
                
                foreach (Dialog dialog in Dialogs)
                {
                     _dialogManager.StartDialog(dialog);
                }
                _dialogManager.DisplayNextSentence();
                Destroy(gameObject);
                if (gameObject.name == "TownNarratorReturns")
                {   
                    GameManager.Instance.isFirstRun = false;
                }
            }
        }
        else
        {
            Debug.LogError("Collision object is null. Make sure it's properly initialized.");
        }
    }
}
