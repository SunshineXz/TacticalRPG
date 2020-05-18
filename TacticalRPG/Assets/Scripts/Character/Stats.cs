using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public abstract class Stat
{
    [HideInInspector]
    public string statName;

    [HideInInspector]
    public int baseValue;

    public int currentValue {
        get { return (int)Math.Ceiling((double)baseValue * jobMultiplier); }
    }

    [HideInInspector]
    public double jobMultiplier;

    protected Stat(int value)
    {
        baseValue = value;
        jobMultiplier = 1.0;
    }

    protected Stat(int value, double multiplier)
    {
        baseValue = value;
        jobMultiplier = multiplier;
    }

    public void upgradeBaseValue(double multiplier)
    {
        baseValue = (int)Math.Ceiling((double)baseValue * multiplier);
    }

    public void upgradeBaseValue(int flatValue)
    {
        baseValue += flatValue;
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
    public HP(int value) : base(value)
    {
        statName = "HP";
    }

    public HP(int value, double jobMultiplier) : base(value, jobMultiplier)
    {
        statName = "HP";
    }
}

[Serializable]
public class Attack : Stat
{
    public Attack(int value) : base(value)
    {
        statName = "Attack";
    }

    public Attack(int value, double jobMultiplier) : base(value, jobMultiplier)
    {
        statName = "Attack";
    }
}

[Serializable]
public class Defense : Stat
{
    public Defense(int value) : base(value)
    {
        statName = "Defense";
    }

    public Defense(int value, double jobMultiplier) : base(value, jobMultiplier)
    {
        statName = "Defense";
    }
}

[Serializable]
public class Speed : Stat
{
    public Speed(int value) : base(value)
    {
        statName = "Speed";
    }

    public Speed(int value, double jobMultiplier) : base(value, jobMultiplier)
    {
        statName = "Speed";
    }
}

//This needs to be done for each stat individually... if we want it
[CustomPropertyDrawer(typeof(Stat), true)]
public class StatInspector : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        EditorGUI.indentLevel = 0;

        SerializedProperty baseValue = property.FindPropertyRelative("baseValue");
        SerializedProperty jobMultiplier = property.FindPropertyRelative("jobMultiplier");


        EditorGUI.IntField(position, (int)Math.Ceiling((double)baseValue.intValue * jobMultiplier.doubleValue));
        EditorGUI.EndProperty();
    }
}