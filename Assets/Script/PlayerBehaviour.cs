using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private CharacterManager charManager;
    [SerializeField] private bool canBlock;
    public delegate void EnnemyCounter();
    public EnnemyCounter _ennemyCounterCallback;

    public bool CanBlock { get => canBlock; set => canBlock = value; }

    void Start()
    {
        charManager = GetComponent<CharacterManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanBlock)
            {
                _ennemyCounterCallback?.Invoke();
            }
        }
        if (charManager.CanAttack)
        {
            charManager.animator.SetTrigger("Attack");
            charManager.CanAttack = false;
        }
    }
}
