using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }

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

    //triggers dialog with the sentences between sentenceIndexStart, and sentenceIndexEnd
    public void TriggerDialog(int sentenceIndexStart,int sentenceIndexEnd)
    {
        var tempDialog = new Dialog();
        var tempSentences = dialog.sentences.Skip(sentenceIndexStart).ToArray();
        tempDialog.name = dialog.name;
        tempDialog.sentences = dialog.sentences.Take(sentenceIndexEnd-sentenceIndexStart).ToArray();
        FindObjectOfType<DialogManager>().StartDialog(tempDialog);
    }
   
 
}
