using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public string Name;
    public Color color = Color.black;

    //Level & Experience
    public int Level = 1;
    public int Experience;
    int ExpNextLevel = 10;

    //Fighting Stats
    public int HP;
    public int Attack;
    public int Defense;
    public int Speed;

    //Base Stats
    //int BaseHP;
    //int BaseAttack;
    //int BaseDefense;
    //int BaseSpeed;



    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.color = color;
    }
	
	// Update is called once per frame
	void Update () {
        Experience++;
        CheckExp();
	}

    private void CheckExp()
    {
        if(Experience > ExpNextLevel)
        {
            Experience = Experience % ExpNextLevel;
            ExpNextLevel *= 2;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;

        //NEED TO UPDATE STATS
        HP = (int)Math.Ceiling((double)HP * 1.1);
        Attack = (int)Math.Ceiling((double)Attack * 1.1);
        Defense = (int)Math.Ceiling((double)Defense * 1.1);
        Speed = (int)Math.Ceiling((double)Speed * 1.1);
    }
}
