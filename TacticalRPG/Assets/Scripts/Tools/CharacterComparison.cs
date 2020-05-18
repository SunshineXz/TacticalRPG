using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpeedComparer : IComparer<Character>
{
    public int Compare(Character x, Character y)
    {
        return y.speed.currentValue.CompareTo(x.speed.currentValue);
    }
}
