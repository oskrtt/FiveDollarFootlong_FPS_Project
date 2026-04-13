using UnityEngine;
using Unity.FPS.Game;

public class Enemy_HoverBot_Alert : MonoBehaviour
{
    public AK.Wwise.Event alertEvent;
    private bool playerDetected = false;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player") && !playerDetected)
        {
            playerDetected = true;

        if (alertEvent != null)
            {
                alertEvent.Post(gameObject);  // Posts the event to this GameObject
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the player leaves the detection zone, reset the detection
        if (other.CompareTag("Player") && playerDetected)
        {
            playerDetected = false;
        }
    }
}