using UnityEngine;

public class BossMusicTrigger : MonoBehaviour
{
    public MusicManager musicManager;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            musicManager.PlayBoss();
        }
    }
}
