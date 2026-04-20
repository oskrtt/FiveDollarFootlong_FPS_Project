using UnityEngine;
using UnityEngine.InputSystem;

public class Debugger : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            Debug.Log("Boss state");
            AkSoundEngine.StopAll();
            AkSoundEngine.SetState("Music", "Boss");
        }
    }
}
