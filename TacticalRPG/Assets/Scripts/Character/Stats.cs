using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0660 // Le type définit l'opérateur == ou l'opérateur != mais ne se substitue pas à Object.Equals(object o)
#pragma warning disable CS0661 // Le type définit l'opérateur == ou l'opérateur != mais ne se substitue pas à Object.GetHashCode()
public abstract class Stat
#pragma warning disable CS0660 // Le type définit l'opérateur == ou l'opérateur != mais ne se substitue pas à Object.Equals(object o)
#pragma warning restore CS0661 // Le type définit l'opérateur == ou l'opérateur != mais ne se substitue pas à Object.GetHashCode()
{
    [HideInInspector]
    public string name;

    [SerializeField]
    public int baseValue;

    [HideInInspector]
    public int currentValue;

    [HideInInspector]
    public double jobMultiplier;

    protected void updateCurrentValue()
    {
        currentValue = (int)Math.Ceiling((double)baseValue * jobMultiplier);
    }

    public void upgradeBaseValue(double multiplier)
    {
        baseValue = (int)Math.Ceiling((double)baseValue * multiplier);
        updateCurrentValue();
    }

    public void upgradeBaseValue(int flatValue)
    {
        baseValue += flatValue;
        updateCurrentValue();
    }

    public void changeJobValue(double multiplier)
    {
        jobMultiplier = multiplier;
    }

    #region Operators
    public static bool operator <(Stat lhs, Stat rhs)
    {
        return lhs.currentValue < rhs.currentValue;
    }

    public static bool operator >(Stat lhs, Stat rhs)
    {
        return lhs.currentValue > rhs.currentValue;
    }

    public static bool operator <=(Stat lhs, Stat rhs)
    {
        return lhs.currentValue <= rhs.currentValue;
    }

    public static bool operator >=(Stat lhs, Stat rhs)
    {
        return lhs.currentValue >= rhs.currentValue;
    }

    public static bool operator ==(Stat lhs, Stat rhs)
    {
        return lhs.currentValue == rhs.currentValue;
    }

    public static bool operator !=(Stat lhs, Stat rhs)
    {
        return lhs.currentValue != rhs.currentValue;
    }

    public static int operator +(Stat lhs, Stat rhs)
    {
        return lhs.currentValue + rhs.currentValue;
    }

    public static int operator -(Stat lhs, Stat rhs)
    {
        return lhs.currentValue - rhs.currentValue;
    }

    public static int operator *(Stat lhs, Stat rhs)
    {
        return lhs.currentValue + rhs.currentValue;
    }

    public static int operator /(Stat lhs, Stat rhs)
    {
        return lhs.currentValue - rhs.currentValue;
    }

    public static int operator %(Stat lhs, Stat rhs)
    {
        return lhs.currentValue % rhs.currentValue;
    }

    #endregion
}

[Serializable]
public class HP : Stat
{
    public HP(int value)
    {
        name = "HP";
        baseValue = value;
        jobMultiplier = 1.0;
        updateCurrentValue();
    }
}

[Serializable]
public class Attack : Stat
{
    public Attack(int value)
    {
        name = "Attack";
        baseValue = value;
        jobMultiplier = 1.0;
        updateCurrentValue();
    }
}

[Serializable]
public class Defense : Stat
{
    public Defense(int value)
    {
        name = "Defense";
        baseValue = value;
        jobMultiplier = 1.0;
        updateCurrentValue();
    }
}

[Serializable]
public class Speed : Stat
{
    public Speed(int value)
    {
        name = "Speed";
        baseValue = value;
        jobMultiplier = 1.0;
        updateCurrentValue();
    }
}



