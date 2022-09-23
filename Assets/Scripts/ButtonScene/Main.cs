using UnityEngine;

public class Main : MainBase 
{
    [SerializeField] private ReduceHealthButton _reduceHealthButton;

    protected override void Init()
    {
        base.Init();
        _reduceHealthButton.Init(_playerHealth);
    }
}