using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion
{
    [SerializeField] int _healingAmount;

    public int HealingAmount { get => _healingAmount; set => _healingAmount = value; }
}
