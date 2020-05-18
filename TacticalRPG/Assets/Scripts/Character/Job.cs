using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public enum JobType
{
    Warrior = 0,
    Mage,
    Rogue,
    Healer
}

[Serializable]
public class Job {

    public string _name;
    public int _jobLevel;
    public double _hpMultiplier;
    public double _attackMultiplier;
    public double _defenseMultiplier;
    public double _speedMultiplier;

    public Job(string name, int jobLevel, double hp, double att, double def, double speed)
    {
        _name = name;
        _jobLevel = jobLevel;
        _hpMultiplier = hp;
        _attackMultiplier = att;
        _defenseMultiplier = def;
        _speedMultiplier = speed;
    }

    public static JobType getJob(string jobName)
    {
        switch (jobName)
        {
            case "Warrior": return JobType.Warrior;
            case "Mage": return JobType.Mage;
            case "Rogue": return JobType.Rogue;
            case "Healer": return JobType.Healer;
            default: return JobType.Warrior;
        }
    }
}

[Serializable]
public class JSONJobList
{
    public JSONJob[] jobList;

    public JSONJob this[int key]
    {
        get
        {
            return jobList[key];
        }
    }

    public List<Job> toList()
    {
        List<Job> jobs = new List<Job>();
        foreach (JSONJob j in jobList)
        {
            jobs.Add(j.ToJob());
        }
        return jobs;
    }
}

[Serializable]
public class JSONJob
{
    public string name;
    public int jobLevel;
    public double hpMultiplier;
    public double attackMultiplier;
    public double defenseMultiplier;
    public double speedMultiplier;

    public Job ToJob()
    {
        return new Job(name, jobLevel, hpMultiplier, attackMultiplier, defenseMultiplier, speedMultiplier);
    }
}