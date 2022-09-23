using System.Collections;
using UnityEngine;

//Timed Events
public class ReduceHealth : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private float _reduceHealthTime = 2f;

    private bool _reducePlayerHealth = false;
    private float _timeSinceLastReduce;

    private Coroutine _reduceHealthRoutine;

    public void Init (PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;

        // StartInvokeRepeating();
        // StartUpdateTimer();

        StartRoutine();
    }

    private void StartRoutine()
    {
        Debug.Log("StartRoutine");

        _reduceHealthRoutine = StartCoroutine(Routine());
        _playerHealth.OnDeath += () => 
        { 
            Debug.Log("OnDeath");
            StopCoroutine(_reduceHealthRoutine);
        };
    }

    private IEnumerator Routine()
    {
        while(true)
        {
            yield return new WaitForSeconds(_reduceHealthTime);
            ReduceOneHealth();
        }
    }

    private void StartUpdateTimer()
    {
        Debug.Log("StartUpdateTimer");

        _reducePlayerHealth = true;
        _timeSinceLastReduce = 0f;
        _playerHealth.OnDeath += () => 
        { 
            Debug.Log("OnDeath");
            _reducePlayerHealth = false;
        };
    }

    private void Update()
    {
        UpdateReduceHealthTimer();
    }

    private void UpdateReduceHealthTimer()
    {
        if(!_reducePlayerHealth)
        {
            return;
        }

        _timeSinceLastReduce += Time.deltaTime;
        if(_timeSinceLastReduce >= _reduceHealthTime)
        {
            ReduceOneHealth();
            _timeSinceLastReduce = 0f;
        }
    }

    private void StartInvokeRepeating()
    {
        Debug.Log("StartInvokeRepeating");
        InvokeRepeating("ReduceOneHealth", 1f, _reduceHealthTime);

        _playerHealth.OnDeath += () => 
        { 
            Debug.Log("OnDeath");
            CancelInvoke("ReduceOneHealth"); 
        };
    }

    private void ReduceOneHealth()
    {
        Debug.Log("ReduceOneHealth");
        _playerHealth.Health -= 1;
    }
}
