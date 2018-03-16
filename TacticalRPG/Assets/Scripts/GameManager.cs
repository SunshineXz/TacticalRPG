using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static GameManager instance;
    public Character[] characters;

    // Use this for initialization
    void Start () {
        instance = this;
        SortCharacters();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static GameManager GetInstance()
    {
        return instance;
    }

    public void SortCharacters()
    {
        Array.Sort(characters, new CharacterSpeedComparer());
    }
}
