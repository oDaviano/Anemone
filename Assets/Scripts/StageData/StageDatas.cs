using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct StageDatas
{
   public string stageName;
   public string stageDifficulty;
   public string Danger;

    public StageDatas(string stageName, string stageDifficulty, string Danger)
    {
        this.stageName = stageName;
        this.stageDifficulty = stageDifficulty;
        this.Danger= Danger;


    }
}
