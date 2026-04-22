using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AK.Wwise.Event playLevelMusic;
    public AK.Wwise.Event playBossMusic;
    public AK.Wwise.Event stopMusic;

    private GameObject audioObject;

    void Awake()
    {
        audioObject = gameObject;
    }

    void Start()
    {
        PlayLevel();
    }

    public void PlayLevel()
    {
        stopMusic.Post(audioObject);
        playLevelMusic.Post(audioObject);
    }

    public void PlayBoss()
    {
        stopMusic.Post(audioObject);
        playBossMusic.Post(audioObject);
    }
}