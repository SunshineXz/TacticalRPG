using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0660 // Le type définit l'opérateur == ou l'opérateur != mais ne se substitue pas à Object.Equals(object o)
#pragma warning disable CS0661 // Le type définit l'opérateur == ou l'opérateur != mais ne se substitue pas à Object.GetHashCode()
public abstract class Stat
#pragma warning restore CS0660 // Le type définit l'opérateur == ou l'opérateur != mais ne se substitue pas à Object.Equals(object o)
#pragma warning restore CS0661 // Le type définit l'opérateur == ou l'opérateur != mais ne se substitue pas à Object.GetHashCode()
{
    [HideInInspector]
    public string name;

    [HideInInspector]
    public int baseValue;

    [SerializeField]
    public int currentValue;

    [HideInInspector]
    public double jobMultiplier;

    protected Stat(int value, double multiplier)
    {
        baseValue = value;
        jobMultiplier = multiplier;
        updateCurrentValue();
    }

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
    public HP(int value, double jobMultiplier) : base(value, jobMultiplier)
    {
        name = "HP";
    }
}

[Serializable]
public class Attack : Stat
{
    public Attack(int value, double jobMultiplier) : base(value, jobMultiplier)
    {
        name = "Attack";
    }
}

[Serializable]
public class Defense : Stat
{
    public Defense(int value, double jobMultiplier) : base(value, jobMultiplier)
    {
        name = "Defense";
    }
}

[Serializable]
public class Speed : Stat
{
    public Speed(int value, double jobMultiplier) : base(value, jobMultiplier)
    {
        name = "Speed";
    }
}



