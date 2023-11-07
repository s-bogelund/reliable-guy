using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public InputAction dialogAdvance = new InputAction("DialogAdvance", binding: "<Keyboard>/space");
    public Animator animator;
    public Text nameText;
    public Text dialogText;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
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
        nameText.text = dialog.name;
        sentences.Clear();
        animator.SetBool("IsOpen", true);
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
            if (sentences.Count <= 0)
            {
                EndDialog();
                return;
            }

            dialogText.text = sentences.Dequeue();
        
    }

    public void EndDialog()
    {
        Debug.Log("End of conversation");
        animator.SetBool("IsOpen", false);


    }
}
