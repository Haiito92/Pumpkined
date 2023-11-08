using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    private CharacterManager charManager;
    [SerializeField] private PlayerBehaviour targetPlayer;
    [SerializeField] private float _cooldown;
    private bool isBlock;

    public bool IsBlock { get => isBlock; set => isBlock = value; }

    void Start()
    {
        charManager = GetComponent<CharacterManager>();
        charManager.animator = GetComponent<Animator>();
        IsBlock = false;
        targetPlayer = charManager.Target.GetComponent<PlayerBehaviour>();
        StartCoroutine(EnnemyAttackCooldown());
        targetPlayer._ennemyCounterCallback += Counter;
    }

    void Update()
    {
        if (charManager.CanAttack)
        {
            charManager.CanAttack = false;
            charManager.animator.SetTrigger("Attack");
            StartCoroutine(EnnemyAttackCooldown());
        }
    }

    IEnumerator EnnemyAttackCooldown()
    {
        yield return new WaitForSeconds(_cooldown);
        charManager.CanAttack = true;
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

}
