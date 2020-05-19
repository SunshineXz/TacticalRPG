using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static CharacterTargetSystem;

public class GameManager : MonoBehaviour {

    static GameManager instance;

    public List<CharacterInfo> charInfoList;
    public List<Character> characters;
    public List<Job> jobList;

    public Character charPrefab;

    public CharacterTargetSystem characterTargetSystem;

    private void Awake()
    {
        instance = this;

        characterTargetSystem = GetComponent<CharacterTargetSystem>();

        JSONReader.Read(out jobList);
        JSONReader.Read(out charInfoList);
    }

    void Start () {
        for(var i = 0; i < charInfoList.Count; ++i)
        {
            var character = Instantiate(charPrefab, new Vector3(i,0,i), new Quaternion());
            character.Initialize(charInfoList[i]);
            characters.Add(character);
        }
        SortCharacters();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void SortCharacters()
    {
        characters.Sort(new CharacterSpeedComparer());
    }

    public TargetState GetState()
    {
        return characterTargetSystem.currentState;
    }
}
