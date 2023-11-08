using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<HealingPotion> _healingPotions = new List<HealingPotion>();


    //Fields created to make the script function, but have to be replaced by the real fields
    int _playerHealth;

    public void UseHealingPotion()
    {
        //Use last potion in the list
        _playerHealth += _healingPotions[_healingPotions.Count - 1].HealingAmount;

        //Remove the last potion in the list
        _healingPotions.RemoveAt(_healingPotions.Count - 1);
    }

}
