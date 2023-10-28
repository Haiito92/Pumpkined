using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private CharacterManager charManager;

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
        if (charManager.CanAttack)
        {;
            charManager.animator.SetTrigger("Attack");
            charManager.CanAttack = false;
        }
    }
}
