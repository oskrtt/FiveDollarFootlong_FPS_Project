using UnityEngine;
using Unity.FPS.Game;

public class PlayerHurt : MonoBehaviour
{
    public AK.Wwise.Event hurtEvent;
    public AK.Wwise.Event deathEvent;

    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (health != null)
        {
            health.OnDamaged += OnPlayerDamaged;
            health.OnDie += OnPlayerDeath;
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (health != null)
        {
            health.OnDamaged -= OnPlayerDamaged;
            health.OnDie -= OnPlayerDeath;
        }
    }

    void OnPlayerDamaged(float damage, GameObject damagesource)
    {
        hurtEvent.Post(gameObject);
    }

    void OnPlayerDeath()
    {
        deathEvent.Post(gameObject);
    }


}
