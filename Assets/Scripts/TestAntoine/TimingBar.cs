using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TimingBar : MonoBehaviour
{
    //Fields
    [SerializeField] float _maxValue = 100;
    [SerializeField] float _currentValue;

    float _fillingValue = 0.1f;
    [SerializeField] float _fillingSpeed = 1f;
    [SerializeField] float _fillingTime = 10f;

    bool _canDoAction = false;

    //Coroutines
    Coroutine _setFill;

    //References
    [SerializeField] Image _fill;

    private void Awake()
    {
        _currentValue = 0;
        _fill.fillAmount = 0;
    }

    private void Start()
    {
        _setFill = StartCoroutine(FillingCoroutine());
    }

    private void Update()
    {
        _fill.fillAmount = _currentValue / _maxValue;
    }

    public void DoAction(InputAction.CallbackContext ctx)
    {
        if(ctx.started && _canDoAction)
        {
            Debug.Log("Do Action");
            _canDoAction = false;
            _currentValue = 0;
        }
    }

    public IEnumerator FillingCoroutine()
    {
        while (true)
        {
            Debug.Log("Fill");
            _fillingValue = (_maxValue / _fillingTime) * _fillingSpeed;
            while (!_canDoAction)
            {
                _currentValue = Mathf.Clamp(_currentValue + _fillingValue, 0, _maxValue);
                yield return new WaitForSeconds(_fillingSpeed);
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
        StopCoroutine(_setFill);
    }

}
