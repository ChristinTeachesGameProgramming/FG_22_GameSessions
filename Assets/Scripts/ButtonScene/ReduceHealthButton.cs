using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ReduceHealthButton : MonoBehaviour
{
    private Button _button;
    private PlayerHealth _playerHealth;

    public void Init(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
        _playerHealth.OnDeath += Disable;

        _button = GetComponent<Button>();
        _button.interactable = true;
        _button.onClick.AddListener(ReduceHealth);
    }

    public void ReduceHealth() 
    {
        _playerHealth.Health -= 1;
    }

    private void Disable() 
    {
        _button.interactable = false;
    }

    private void OnDestroy()
    {
        _playerHealth.OnDeath -= Disable;
    }
}
