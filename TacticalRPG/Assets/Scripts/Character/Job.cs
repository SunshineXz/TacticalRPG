using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum Jobs
{
    Warrior = 0,
    Mage,
    Rogue,
    Healer
}

[Serializable]
public class Job {

    public string name;
    public int jobLevel;
    public double hpMultiplier;
    public double attackMultiplier;
    public double defenseMultiplier;
    public double speedMultiplier;
}

[Serializable]
public class JobList
{
    public Job[] jobList;

    public Job this[int key]
    {
        get
        {
            return jobList[key];
        }
        set
        {
            jobList[key] = value;
        }
    }

}
