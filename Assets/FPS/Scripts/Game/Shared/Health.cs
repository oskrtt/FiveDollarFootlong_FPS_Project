using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Game
{
    public class Health : MonoBehaviour
    {
        [Header("Health")]
        public float MaxHealth = 10f;
        public float CriticalHealthRatio = 0.3f;

        [Header("Audio")]
        public AudioSource HeartbeatAudioSource;
        public AudioClip HeartbeatClip;

        public UnityAction<float, GameObject> OnDamaged;
        public UnityAction<float> OnHealed;
        public UnityAction OnDie;

        public float CurrentHealth { get; set; }
        public bool Invincible { get; set; }

        bool m_IsDead;
        Coroutine m_HeartbeatRoutine;

        public float GetRatio() => CurrentHealth / MaxHealth;
        public bool IsCritical() => GetRatio() <= CriticalHealthRatio;

        void Start()
        {
            CurrentHealth = MaxHealth;

            if (HeartbeatAudioSource != null && HeartbeatClip != null)
            {
                HeartbeatAudioSource.clip = HeartbeatClip;
                HeartbeatAudioSource.loop = true;
                HeartbeatAudioSource.playOnAwake = false;
            }
        }

        void OnEnable()
        {
            m_HeartbeatRoutine = StartCoroutine(HeartbeatWatcher());
        }

        void OnDisable()
        {
            if (m_HeartbeatRoutine != null)
            {
                StopCoroutine(m_HeartbeatRoutine);
                m_HeartbeatRoutine = null;
            }

            if (HeartbeatAudioSource != null)
            {
                HeartbeatAudioSource.Stop();
            }
        }

        System.Collections.IEnumerator HeartbeatWatcher()
        {
            while (true)
            {
                float ratio = CurrentHealth / MaxHealth;

                if (ratio <= CriticalHealthRatio)
                {
                    if (HeartbeatAudioSource != null && !HeartbeatAudioSource.isPlaying)
                    {
                        HeartbeatAudioSource.Play();
                        Debug.Log("Heartbeat START");
                    }
                }
                else
                {
                    if (HeartbeatAudioSource != null && HeartbeatAudioSource.isPlaying)
                    {
                        HeartbeatAudioSource.Stop();
                        Debug.Log("Heartbeat STOP");
                    }
                }

                yield return new WaitForSeconds(0.2f);
            }
        }

        public void Heal(float healAmount)
        {
            float healthBefore = CurrentHealth;

            CurrentHealth += healAmount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

            float trueHealAmount = CurrentHealth - healthBefore;

            if (trueHealAmount > 0f)
            {
                OnHealed?.Invoke(trueHealAmount);
            }
        }

        public void TakeDamage(float damage, GameObject damageSource)
        {
            if (Invincible)
                return;

            float healthBefore = CurrentHealth;

            CurrentHealth -= damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

            float trueDamageAmount = healthBefore - CurrentHealth;

            if (trueDamageAmount > 0f)
            {
                OnDamaged?.Invoke(trueDamageAmount, damageSource);
            }

            HandleDeath();
        }

        public void Kill()
        {
            CurrentHealth = 0f;

            OnDamaged?.Invoke(MaxHealth, null);

            HandleDeath();
        }

        void HandleDeath()
        {
            if (m_IsDead)
                return;

            if (CurrentHealth <= 0f)
            {
                m_IsDead = true;

                if (HeartbeatAudioSource != null)
                {
                    HeartbeatAudioSource.Stop();
                }

                OnDie?.Invoke();
            }
        }

        public bool CanPickup()
        {
            return CurrentHealth < MaxHealth;
        }
    }
}