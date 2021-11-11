using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CombineInfo
{
    
    public string resultName;
    public string m1Name;
    public string m2Name;
    public string m3Name;
    public string m4Name;

    public int m1Count;
    public int m2Count;
    public int m3Count;
    public int m4Count;



    public CombineInfo(string resultName, string m1Name, int m1Count, string m2Name, int m2Count, string m3Name, int m3Count, string m4Name,  int m4Count)
    {

        this.resultName = resultName;
        this.m1Name = m1Name;
        this.m2Name = m2Name;
        this.m3Name = m3Name;
        this.m4Name = m4Name;

        this.m1Count = m1Count;
        this.m2Count = m2Count;
        this.m3Count = m3Count;
        this.m4Count = m4Count;
    }

};
