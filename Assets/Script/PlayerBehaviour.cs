using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private CharacterManager charManager;
    private bool canBlock;

    public bool CanBlock { get => canBlock; set => canBlock = value; }

    void Start()
    {
        charManager = GetComponent<CharacterManager>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charManager.CanAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (CanBlock)
            {

            }
        }
        if (charManager.CanAttack)
        {
            charManager.animator.SetTrigger("Attack");
            charManager.CanAttack = false;
        }
    }
}
