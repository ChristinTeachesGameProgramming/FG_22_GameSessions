using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealthSetup", menuName = "ScriptableObjects/PlayerHealthSetup", order = 1)]
public class PlayerHealthSetup : ScriptableObject 
{
    [SerializeField] private float _maxHealth;

    public float MaxHealth => _maxHealth;
}