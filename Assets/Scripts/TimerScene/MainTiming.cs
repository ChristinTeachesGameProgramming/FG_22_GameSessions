using UnityEngine;

public class MainTiming : MainBase 
{
    [SerializeField] private ReduceHealth _reduceHealth;

    protected override void Init()
    {
        base.Init();
        
        _reduceHealth.Init(_playerHealth);
    }
}