using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInfo : MonoBehaviour
{
    public string talker;

    public string script;

    public int expression;

public DialogInfo(string talker, string script, int expression)
    {
        this.talker = talker;
        this.script = script;
        this.expression = expression;



    }
}

