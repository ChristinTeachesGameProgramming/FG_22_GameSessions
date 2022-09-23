public class PlayerHealth 
{
    private float _maxHealth;
    private float _health;
    public float Health {
        get => _health; 
        set 
        {
            _health = value;
            OnHealthUpdate?.Invoke();

            if(_health <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }

    public float HealthPercentage => Health / _maxHealth;

    public delegate void HealthUpdate();
    public HealthUpdate OnHealthUpdate;

    public HealthUpdate OnDeath;

    public PlayerHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        Health = maxHealth;
    }
}