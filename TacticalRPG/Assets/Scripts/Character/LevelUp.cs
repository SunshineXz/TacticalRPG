using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelSystem {
    const int MAX_LEVEL = 10;

    //Level & Experience
    public int Level = 1;
    public int Experience;
    int[] ToLevelUp;

    Character character;


    public LevelSystem(Character c)
    {
        character = c;

        Level = 1;
        Experience = 0;
        ToLevelUp = new int[] {0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };  // READ FROM CSV FILE
    }

    void LevelUp()
    {
        Level += 1;

        character.hp.upgradeBaseValue(1.1);
        character.attack.upgradeBaseValue(1.1);
        character.defense.upgradeBaseValue(1.1);
        character.speed.upgradeBaseValue(1.1);
    }

    void CheckExperience()
    {
        int ToLevelUpExp = ToLevelUp[Level];
        while (Experience >= ToLevelUpExp && Level < MAX_LEVEL)
        {
            Experience = Experience % ToLevelUpExp;
            LevelUp();
        }
    }

    public void AddExperience(int exp)
    {
        Experience += exp;
        CheckExperience();
    }
}
