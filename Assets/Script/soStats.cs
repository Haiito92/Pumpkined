using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Stats")]
public class soStats : ScriptableObject
{
    public int health;
    public int damage;
    public string statName;
}
