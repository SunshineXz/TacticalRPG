using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static GameManager Instance;
    public Character[] characters;

    // Use this for initialization
    void Start () {
        Instance = this;
        SortCharacters();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static GameManager GetInstance()
    {
        return Instance;
    }

    public void SortCharacters()
    {
        Array.Sort(characters, new CharacterSpeedComparer());
    }
}
