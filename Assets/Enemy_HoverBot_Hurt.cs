using UnityEngine;
using Unity.FPS.Game;

public class Enemy_HoverBot_Hurt : MonoBehaviour
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
            health.OnDamaged += OnEnemyDamaged;
            health.OnDie += OnEnemyDeath;
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (health != null)
        {
            health.OnDamaged -= OnEnemyDamaged;
            health.OnDie -= OnEnemyDeath;
        }
    }

    void OnEnemyDamaged(float damage, GameObject damagesource)
    {
        hurtEvent.Post(gameObject);
    }
    void OnEnemyDeath()
    {
        deathEvent.Post(gameObject);
    }
}
