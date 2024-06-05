using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AchievementData
{
    public string name;
    public string description;
    public int[] maxCount;
    public int id;
    public bool clear = false;
    public int level=0;
    public int curCount=0;

    public AchievementData(string name, string description, int[] maxCount, int id)
    {
        this.name = name;
        this.description = description;
        this.maxCount = maxCount;
        this.id = id;
    }
}
