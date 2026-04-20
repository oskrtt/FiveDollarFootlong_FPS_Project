using UnityEngine;

public class BossMusicTrigger : MonoBehaviour
{
    //public static bool bossMusicLocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            //bossMusicLocked = true;
            AkSoundEngine.SetState("Music", "Boss");
        }
    }
}
