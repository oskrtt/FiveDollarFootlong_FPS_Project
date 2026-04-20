using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AK.Wwise.Event playMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playMusic.Post(gameObject);
        AkSoundEngine.SetState("Music", "Level");
      
    }

}
