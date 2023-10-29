using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TimingBar : MonoBehaviour
{
    //Fields
    [SerializeField] float _maxValue = 100;
    float _currentValue;

    float _fillingValue = 0.1f;
    float _fillingTickSpeed = 0.01f;
    [SerializeField] float _fillingTime = 10f;

    bool _canDoAction = false;

    //Coroutines
    Coroutine _fillingCoroutine;

    //References
    [SerializeField] Image _fill;

    #region Properties
    public bool CanDoAction { get => _canDoAction; set => _canDoAction = value; }
    #endregion


    private void Awake()
    {
        _currentValue = 0;
        _fill.fillAmount = 0;
    }

    private void Start()
    {
        StartFillingCoroutine();
    }

    private void Update()
    {
        _fill.fillAmount = _currentValue / _maxValue;
    }

    public void DoAction()
    {
        if(_canDoAction)
        {
            Debug.Log("Do Action");
            _canDoAction = false;
            _currentValue = 0;
        }
    }

    void StartFillingCoroutine()
    {
        _fillingCoroutine = StartCoroutine(FillingCoroutine());
    }

    IEnumerator FillingCoroutine()
    {
        while (true)
        {
            Debug.Log("Fill");
            _fillingValue = (_maxValue / _fillingTime) * _fillingTickSpeed;
            while (!_canDoAction)
            {
                _currentValue = Mathf.Clamp(_currentValue + _fillingValue, 0, _maxValue);
                yield return new WaitForSeconds(_fillingTickSpeed);
                if (_currentValue >= _maxValue)
                {
                    _canDoAction = true;
                }
            }
            Debug.Log("EndFill");

            yield return new WaitUntil(() => _canDoAction == false);
        }
    }

    void StopFillingCoroutine()
    {
        StopCoroutine(_fillingCoroutine);
    }

}
