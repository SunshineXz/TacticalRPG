using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelSystem {
    const int MAX_LEVEL = 10;

    //Level & Experience
    public int level = 1;
    public int experience;
    int[] toLevelUp;

    Character character;


    public LevelSystem(Character c)
    {
        character = c;

        level = 1;
        experience = 0;
        toLevelUp = new int[] {0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };  // READ FROM CSV FILE
    }

    public LevelSystem(Character c, int currentLevel, int experience)
    {
        character = c;

        this.level = 1;
        this.experience = experience;
        toLevelUp = new int[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };  // READ FROM CSV FILE

        while (this.level < currentLevel) LevelUp();
    }

    void LevelUp()
    {
        level += 1;

        character.hp.upgradeBaseValue(1.1);
        character.attack.upgradeBaseValue(1.1);
        character.defense.upgradeBaseValue(1.1);
        character.speed.upgradeBaseValue(1.1);
    }

    void CheckExperience()
    {
        int ToLevelUpExp = toLevelUp[level];
        while (experience >= ToLevelUpExp && level < MAX_LEVEL)
        {
            experience = experience % ToLevelUpExp;
            LevelUp();
        }
    }

    public void AddExperience(int exp)
    {
        experience += exp;
        CheckExperience();
    }
}
