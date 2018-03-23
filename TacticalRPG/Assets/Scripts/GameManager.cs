using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {
    const string jobsFile = "Jobs.json";

    static GameManager instance;
    public List<Character> characterList;
    public JobList jobList;

    private void Awake()
    {
        instance = this;

        JSONReader.Read(out jobList);
        JSONReader.Read(out characterList);
    }

    // Use this for initialization
    void Start () {
        SortCharacters();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void SortCharacters()
    {
        //Array.Sort(characters, new CharacterSpeedComparer());
    }
}
