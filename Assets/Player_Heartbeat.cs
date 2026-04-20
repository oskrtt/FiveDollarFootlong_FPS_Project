using UnityEngine;

public class PlayerHeartbeat : MonoBehaviour
{
public float maxHealth = 100f;
public float currentHealth = 100f;

private bool heartbeatPlaying = false;

void Start()
{
// Start heartbeat loop once
AkSoundEngine.PostEvent("Play_Heartbeat", gameObject);
heartbeatPlaying = true;

// Set initial state
AkSoundEngine.SetState("PlayerLife", "Alive");

// Initialize RTPC
UpdateHealthRTPC();
}

void Update()
{
// Example: testing damage
if (Input.GetKeyDown(KeyCode.H))
{
TakeDamage(10f);
}
}

public void TakeDamage(float damage)
{
currentHealth -= damage;
currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

UpdateHealthRTPC();

if (currentHealth <= 0)
{
OnDeath();
}
}

void UpdateHealthRTPC()
{
// Normalize to 0–100 if needed
float healthPercent = (currentHealth / maxHealth) * 100f;

// Send to Wwise
AkSoundEngine.SetRTPCValue("PlayerHealth", healthPercent, gameObject);
}

void OnDeath()
{
AkSoundEngine.SetState("PlayerLife", "Defeated");
}
}