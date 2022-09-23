using System;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image _healthFill;

    // [SerializeField][Range(0,1)] private float _percentage;
    // [SerializeField] private float _health;
    // [SerializeField] private float _maxHealth;

    private PlayerHealth _playerHealth;

    internal void Init(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
        _playerHealth.OnHealthUpdate += UpdateHealth;
    }

    // private void Update() 
    // {
    //     // var percentage = _health / _maxHealth;
    //     // Debug.Log($"percentage {percentage}");
    //     // _healthFill.fillAmount = _playerHealth.HealthPercentage;
    // }

    private void UpdateHealth()
    {
        _healthFill.fillAmount = _playerHealth.HealthPercentage;
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthUpdate -= UpdateHealth;
    }
}
