using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private CharacterManager charManager;
    [SerializeField] private bool canBlock;
    private bool allowToBlock;
    public delegate void EnnemyCounter();
    public EnnemyCounter _ennemyCounterCallback;
    private TimingBar _timingBar;
    [SerializeField] private GameObject _canvas;

    public bool CanBlock { get => canBlock; set => canBlock = value; }
    public bool AllowToBlock { get => allowToBlock; set => allowToBlock = value; }

    void Start()
    {
        charManager = GetComponent<CharacterManager>();
        _timingBar = GetComponent<TimingBar>();
        AllowToBlock = false;
        charManager.CanAttack = false;
    }
    void Update()
    {
        if (AllowToBlock)
        {
            _canvas.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CanBlock)
                {
                    _ennemyCounterCallback?.Invoke();
                }
            }
            if (_timingBar.CanDoAction)
            {

                _timingBar.DoAction();
                _canvas.SetActive(true);
                AllowToBlock = false;
            }
        }

        if (charManager.CanAttack)
        {
            _canvas.SetActive(false);
            if (_timingBar.CanDoAction)
            {
                _timingBar.DoAction();
                charManager.animator.SetTrigger("Attack");
                charManager.CanAttack = false;
                _canvas.SetActive(true);
            }

        }
    }

    public void Die()
    {
        GameManager.Instance.LoseGame();
    }
}
