using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private soStats _stats;
    [SerializeField] private GameObject _target;
    private CharacterManager targetStats;
    public Animator animator;
    private bool canAttack;

    [SerializeField] private int Health;

    public bool CanAttack { get => canAttack; set => canAttack = value; }
    public CharacterManager TargetStats { get => targetStats; set => targetStats = value; }
    public GameObject Target { get => _target; set => _target = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CanAttack = false;
        TargetStats = Target.GetComponent<CharacterManager>();
    }

    private void Update()
    {
        Health = _stats.health;
    }

    private void Changetarget(GameObject newTarget)
    {
        Target = newTarget;
        TargetStats = Target.GetComponent<CharacterManager>();
    }
    private void DealDamage()
    {
        TargetStats._stats.health -= _stats.damage;
    }
}
