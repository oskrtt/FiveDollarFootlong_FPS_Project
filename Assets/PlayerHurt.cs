using UnityEngine;
using Unity.FPS.Game;

public class PlayerHurt : MonoBehaviour
{
    public AK.Wwise.Event hurtEvent;

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
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (health != null)
        {
            health.OnDamaged -= OnPlayerDamaged;
        }
    }

    void OnPlayerDamaged(float damage, GameObject damagesource)
    {
        hurtEvent.Post(gameObject);
    }
}
