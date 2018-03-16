using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : IStat
{

    public string name;
    public int baseValue;
    public int currentValue;
    public double jobMultiplier;

    public Stat()
    {
        name = "";
        baseValue = 0;
        currentValue = 0;
        jobMultiplier = 0.0;
    }

    private void updateCurrentValue()
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

public class HP : Stat { }
public class Attack : Stat { }
public class Defense : Stat { }
public class Speed : Stat { }



