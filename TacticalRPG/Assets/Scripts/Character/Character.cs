using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Character : Movable {

    [Header("Character Information")]

    public string name;

    [SerializeField]
    Jobs jobName = 0;

    [HideInInspector]
    public Job job;

    public LevelSystem levelSystem;

    //Fighting Stats
    [Header("Battle Statistics")]
    public HP hp;
    public Attack attack;
    public Defense defense;
    public Speed speed;

    public Character() : base() { }

    public Character(string name, string jobString, int level, int experience, int hpValue, int attackValue, int defenseValue, int speedValue) : base()
    {
        this.name = name;
        jobName = JobsHelper.getJob(jobString);
        job = GameManager.GetInstance().jobList[(int)jobName]; //TEMP BEFORE JSONREADER
        hp = new HP(hpValue, job.hpMultiplier);
        attack = new Attack(attackValue, job.attackMultiplier);
        defense = new Defense(defenseValue, job.defenseMultiplier);
        speed = new Speed(speedValue, job.speedMultiplier);

        levelSystem = new LevelSystem(this, level, experience);
    }

    // Use this for initialization
    void Start () {
        levelSystem = new LevelSystem(this);
        job = GameManager.GetInstance().jobList[(int)jobName]; //TEMP BEFORE JSONREADER

        // TEMP BEFORE JSONREADER
        hp = new HP(20, job.hpMultiplier);
        attack = new Attack(20, job.attackMultiplier);
        defense = new Defense(20, job.defenseMultiplier);
        speed = new Speed(20, job.speedMultiplier);
    }

    // Update is called once per frame
    void Update () {
        levelSystem.AddExperience(11);
	}

    public void changeJob(Jobs jobName)
    {
        this.jobName = jobName;
        job = GameManager.GetInstance().jobList[(int)jobName];
        hp.changeJobValue(job.hpMultiplier);
        attack.changeJobValue(job.attackMultiplier);
        defense.changeJobValue(job.defenseMultiplier);
        speed.changeJobValue(job.speedMultiplier);
    }
}

[Serializable]
public class JSONCharacterList
{
    public JSONCharacter[] characterList;

    public JSONCharacter this[int key]
    {
        get
        {
            return characterList[key];
        }
    }

    public List<Character> toCharacterList()
    {
        List<Character> characters = new List<Character>();
        foreach(JSONCharacter c in characterList)
        {
            characters.Add(c.ToCharacter());
        }
        return characters;
    }
}

[Serializable]
public class JSONCharacter
{
    public string name;
    public string job;
    public int level;
    public int experience;
    public int hp;
    public int attack;
    public int defense;
    public int speed;

    public Character ToCharacter()
    {
        return new Character(name, job, level, experience, hp, attack, defense, speed); ;
    }
}