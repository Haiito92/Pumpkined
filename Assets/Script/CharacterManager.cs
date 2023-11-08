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

    [SerializeField] private HealthBar _healthBar;

    public bool CanAttack { get => canAttack; set => canAttack = value; }
    public CharacterManager TargetStats { get => targetStats; set => targetStats = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public HealthBar HealthBar { get => _healthBar; set => _healthBar = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        TargetStats = Target.GetComponent<CharacterManager>();
        _stats.health = _stats.maxHealth;
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
        //TargetStats._stats.health -= _stats.damage;
        TargetStats._stats.health = Mathf.Clamp(TargetStats._stats.health - _stats.damage, 0, TargetStats._stats.maxHealth);
        TargetStats.HealthBar.SetFill(TargetStats._stats.health, TargetStats._stats.maxHealth);
        if(TargetStats._stats.health <= 0)
        {
            TargetStats.Die();
        }
    }

    public void Heal(int amount)
    {
        _stats.health = Mathf.Clamp(_stats.health + amount, 0, _stats.maxHealth);
        _healthBar.SetFill(_stats.health, _stats.maxHealth);
    }

    public void Die()
    {
        if(TargetStats.GetComponent<EnnemyBehaviour>() != null)
        {
            TargetStats.GetComponent<EnnemyBehaviour>().Die();
        }
        else if(TargetStats.GetComponent<PlayerBehaviour>() != null)
        {
            TargetStats.GetComponent<PlayerBehaviour>().Die();
        }
    }
}
