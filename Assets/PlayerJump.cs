using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public AK.Wwise.Event jumpEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }
        
    }

    void Jump()
    {
        AkSoundEngine.PostEvent("Player_Jump", gameObject);
    }
}
