using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<HealingPotion> _healingPotions = new List<HealingPotion>();
    CharacterManager _player;
    TimingBar _playerTimingBar;

    private void Awake()
    {
        _player = GetComponent<CharacterManager>();
        _playerTimingBar = GetComponent<TimingBar>();
    }

    private void Start()
    {
        HealingPotion hp = new HealingPotion();
        _healingPotions.Add(hp);
        _healingPotions.Add(hp);
        _healingPotions.Add(hp);
    }

    public void UseHealingPotion()
    {
        if (_playerTimingBar.CanDoAction && _healingPotions.Count > 0)
        {
            _playerTimingBar.DoAction();

            //Use last potion in the list
            _player.Heal(_healingPotions[_healingPotions.Count - 1].HealingAmount);

            //Remove the last potion in the list
            _healingPotions.RemoveAt(_healingPotions.Count - 1);

        }
        else
        {
            //Say to player "Can"t do action"
            Debug.Log("Peux pas heal");
        }
    }

}
