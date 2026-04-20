using UnityEngine;
using Unity.FPS.Game;

public class BossMusicListener : MonoBehaviour
{
    public AK.Wwise.Event playMusic;
    private Health bossHealth;

    void Start()
    {
        bossHealth = GetComponent<Health>();

        if (bossHealth != null)
        {
            bossHealth.OnDie += OnBossDied;
        }
    }

    void OnBossDied()
    {
        //playMusic.Post(gameObject);
        // Switch back to exploration music
        AkSoundEngine.SetState("Music", "Level");

        // Optional: unlock your boss lock if you used one
        //BossMusicTrigger.bossMusicLocked = false;
    }

    void OnDestroy()
    {
        if (bossHealth != null)
        {
            bossHealth.OnDie -= OnBossDied;
        }
    }
}