using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public InputAction dialogAdvance = new InputAction("DialogAdvance", binding: "<Keyboard>/space");
    public Animator animator;
    public Text nameText;
    public Text dialogText;
    private Queue<Dialog> dialogs;
    private Dialog currentDialog;
    // Start is called before the first frame update
    void Start()
    {
        dialogs = new Queue<Dialog>(10000);
        currentDialog = new Dialog();
        dialogAdvance.Enable();
    }

    void Update()
    {
        if (dialogAdvance.triggered)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialog(Dialog dialog)
    {
        Debug.Log("Starting conversation with " + dialog.name);
        animator.SetBool("IsOpen", true);
        dialogs.Enqueue(dialog);

    }

    public void DisplayNextSentence()
    {
        Debug.Log(dialogs.Count);
           
            if (currentDialog?.sentences.Length <= 0)
            {
                if (dialogs.Count <= 0)
                {
                    EndDialog();
                    return;
                }
            Debug.Log("dequeuing dialog");
            currentDialog = dialogs.Dequeue();
            nameText.text = currentDialog.name;
            }

            if (currentDialog != null)
            {
                Debug.Log("Displaying next sentence" + currentDialog.sentences[0]);
                dialogText.text = currentDialog.sentences[0];
                currentDialog.sentences = currentDialog.sentences[1..];
            }
        else
        {
            Debug.LogError("currentDialog is null. Make sure it's properly initialized.");
        }
    }

    public void EndDialog()
    {
        Debug.Log("End of conversation");
        animator.SetBool("IsOpen", false);


    }
}
