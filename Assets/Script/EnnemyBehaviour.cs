using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    private CharacterManager charManager;
    [SerializeField] private PlayerBehaviour targetPlayer;
    [SerializeField] private float _cooldown;
    private bool isBlock;
    private TimingBar _timingBar;

    public bool IsBlock { get => isBlock; set => isBlock = value; }

    void Start()
    {
        charManager = GetComponent<CharacterManager>();
        charManager.animator = GetComponent<Animator>();
        IsBlock = false;
        targetPlayer = charManager.Target.GetComponent<PlayerBehaviour>();
        targetPlayer._ennemyCounterCallback += Counter;
        _timingBar = GetComponent<TimingBar>();
        _timingBar.FillingTime = _cooldown;
        charManager.CanAttack = true;
    }

    void Update()
    {
        if (_timingBar.CanDoAction)
        {
            charManager.CanAttack = true;
            _timingBar.DoAction();
            charManager.animator.SetTrigger("Attack");
            charManager.CanAttack = false;
        }
    }
    void PlayerDef()
    {
        charManager.Target.GetComponent<PlayerBehaviour>().CanBlock = !charManager.Target.GetComponent<PlayerBehaviour>().CanBlock;
    }
    void Counter()
    {
        charManager.animator.SetTrigger("Counter");
        charManager.Target.GetComponent<PlayerBehaviour>().CanBlock = false;
    }

    public void Die()
    {
        GameManager.Instance.LoseGame();
    }

}
