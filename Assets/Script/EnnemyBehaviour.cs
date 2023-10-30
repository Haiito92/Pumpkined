using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    private CharacterManager charManager;

    private bool isBlock;

    public bool IsBlock { get => isBlock; set => isBlock = value; }

    void Start()
    {
        charManager = GetComponent<CharacterManager>();
        charManager.animator = GetComponent<Animator>();
        IsBlock = false;
        StartCoroutine(EnnemyAttackCooldown());
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
        yield return new WaitForSeconds(3f);
        charManager.CanAttack = true;
    }

    void PlayerDef()
    {
        charManager.Target.GetComponent<PlayerBehaviour>().CanBlock = !charManager.Target.GetComponent<PlayerBehaviour>().CanBlock;
    }
}
