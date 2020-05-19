using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable]
public class Character : MonoBehaviour {

    [Header("Character Information")]

    public string characterName;

    [SerializeField]
    JobType jobName = 0;

    [HideInInspector]
    public Job job;

    public LevelSystem levelSystem;

    //Fighting Stats
    [Header("Battle Statistics")]
    public HP hp;
    public Attack attack;
    public Defense defense;
    public Speed speed;

    private GameManager manager;

    public void Start()
    {
        manager = GameManager.GetInstance();
    }

    public void Update () {
        if (manager.GetState() == CharacterTargetSystem.TargetState.Normal)
        {
            CheckRayCast();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            levelSystem.AddExperience(11);
        }
    }

    public void Initialize(CharacterInfo info)
    {
        gameObject.name = info.name;
        characterName = info.name;
        jobName = Job.getJob(info.job);
        job = GameManager.GetInstance().jobList[(int)jobName]; //TEMP BEFORE JSONREADER
        hp = new HP(info.hp, job._hpMultiplier);
        attack = new Attack(info.attack, job._attackMultiplier);
        defense = new Defense(info.defense, job._defenseMultiplier);
        speed = new Speed(info.speed, job._speedMultiplier);

        levelSystem = new LevelSystem(this, info.level, info.experience);
    }

    public void changeJob(JobType jobName)
    {
        this.jobName = jobName;
        job = GameManager.GetInstance().jobList[(int)jobName];
        hp.changeJobValue(job._hpMultiplier);
        attack.changeJobValue(job._attackMultiplier);
        defense.changeJobValue(job._defenseMultiplier);
        speed.changeJobValue(job._speedMultiplier);
    }

    public void MoveToTile(Tile tile)
    {
        transform.position = new Vector3(tile.transform.position.x, transform.position.y, tile.transform.position.z);
        tile.ChangeColor(Color.white);
    }

    void CheckRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        Collider coll = GetComponent<Collider>();
        if (coll.Raycast(ray, out info, 20))
        {
            if (Input.GetMouseButton(0))
            {
                OnTileClicked();
            }
            else
            {
                OnTileHovered();
            }
        }
        else
        {
            ChangeColor(Color.white);
        }
    }

    private void OnTileHovered()
    {
        ChangeColor(Color.blue);
    }

    private void OnTileClicked()
    {
        ChangeColor(Color.green);
    }

    public void ChangeColor(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}

[Serializable]
public class JSONCharacterList
{
    public CharacterInfo[] characterList;

    public CharacterInfo this[int key]
    {
        get
        {
            return characterList[key];
        }
    }

    public List<CharacterInfo> toCharacterList()
    {
        return characterList.ToList();
    }
}

[Serializable]
public class CharacterInfo
{
    public string name;
    public string job;
    public int level;
    public int experience;
    public int hp;
    public int attack;
    public int defense;
    public int speed;
}