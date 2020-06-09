using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static CharacterTargetSystem;

public class GameManager : MonoBehaviour {

    static GameManager instance;

    public List<CharacterInfo> charInfoList;
    public List<Character> characters;
    public List<Job> jobList;
    public List<HexCell> tiles;

    public Character charPrefab;

    public CharacterTargetSystem characterTargetSystem;

    public HexGrid grid;


    private void Awake()
    {
        instance = this;

        characterTargetSystem = GetComponent<CharacterTargetSystem>();

        JSONReader.Read(out jobList);
        JSONReader.Read(out charInfoList);
    }

    public void SpawnCharacters()
    {
        for (var i = 0; i < charInfoList.Count; ++i)
        {
            var character = Instantiate(charPrefab);
            character.MoveToTile(tiles[i]);
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

    public void AddTiles(HexCell[] tileArray)
    {
        tiles.AddRange(tileArray);
    }

    public void Triangulate()
    {
        grid.Triangulate();
    }

    public void SetCells(HexCell[] cells)
    {
        tiles = cells.ToList();
    }
}
