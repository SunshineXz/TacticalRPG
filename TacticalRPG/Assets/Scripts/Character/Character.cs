using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Character : Movable {
    public string Name;

    //Fighting Stats
    public HP hp;
    public Attack attack;
    public Defense defense;
    public Speed speed;

    LevelSystem levelSystem;

    // Use this for initialization
    void Start () {
        levelSystem = new LevelSystem(this);
    }
	
	// Update is called once per frame
	void Update () {
        levelSystem.AddExperience(11);
	}
}
