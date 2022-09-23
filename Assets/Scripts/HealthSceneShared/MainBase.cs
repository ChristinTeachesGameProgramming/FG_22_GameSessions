using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBase : MonoBehaviour 
{
    [SerializeField] private Healthbar _healthBar;
    [SerializeField] private PlayerHealthSetup _playerHealthSetup;

    protected PlayerHealth _playerHealth;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        _playerHealth = new PlayerHealth(_playerHealthSetup.MaxHealth);
        _healthBar.Init(_playerHealth);

        _playerHealth.OnDeath += () => { StartCoroutine(LoadSceneDelayed()); };
    }

    private IEnumerator LoadSceneDelayed() 
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
}