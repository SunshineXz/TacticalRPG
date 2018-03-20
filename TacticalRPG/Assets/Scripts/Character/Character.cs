using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Character : Movable {

    [Header("Character Information")]

    public string Name;

    [SerializeField]
    Jobs JobName = 0;

    [HideInInspector]
    public Job job;

    public LevelSystem levelSystem;

    //Fighting Stats
    [Header("Battle Statistics")]
    public HP hp;
    public Attack attack;
    public Defense defense;
    public Speed speed;

    // Use this for initialization
    void Start () {
        levelSystem = new LevelSystem(this);
        job = GameManager.GetInstance().jobList[(int)JobName]; //TEMP BEFORE JSONREADER

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
}
