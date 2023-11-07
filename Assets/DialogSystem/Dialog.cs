using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog 
{
    [TextArea(3, 10)]
    public string[] sentences;
    public string name;

    public Dialog()
    {
        sentences = new string[0];
        name = "";
    }
    public Dialog(string name, string[] sentences)
    {
        this.name = name;
        this.sentences = sentences;
    }

}
