using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealingPotion
{
    [SerializeField] int _healingAmount = 25; 
    public int HealingAmount { get => _healingAmount; set => _healingAmount = value; }
}
