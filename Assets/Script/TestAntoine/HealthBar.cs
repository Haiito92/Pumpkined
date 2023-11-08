using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _fill;
    public void SetFill(int currentHealth, int maxhealth)
    {
        _fill.fillAmount = (float)currentHealth/maxhealth;
    }
}
