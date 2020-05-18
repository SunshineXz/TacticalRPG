using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONReader {

    const string jobsFilename = "Jobs.json";
    const string charactersFilename = "Characters.json";

    public static void Read(out List<Job> jobList)
    {
        string jobsPath = Path.Combine(Application.streamingAssetsPath, jobsFilename);
        if (File.Exists(jobsPath))
        {
            string JSON = File.ReadAllText(jobsPath);
            jobList = JsonUtility.FromJson<JSONJobList>(JSON).toList();
        }
        else
        {
            jobList = new List<Job>();
        }
    }

    public static void Read(out List<CharacterInfo> characterList)
    {
        string charactersPath = Path.Combine(Application.streamingAssetsPath, charactersFilename);
        if (File.Exists(charactersPath))
        {
            string JSON = File.ReadAllText(charactersPath);
            characterList = JsonUtility.FromJson<JSONCharacterList>(JSON).toCharacterList();
        }
        else
        {
            characterList = new List<CharacterInfo>();
        }
    }
}
