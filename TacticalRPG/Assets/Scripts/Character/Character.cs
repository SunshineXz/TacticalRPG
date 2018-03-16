using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Character : Movable {

    [Header("Character Information")]
    public string Name;
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
    }
	
	// Update is called once per frame
	void Update () {
        levelSystem.AddExperience(11);
	}
}
