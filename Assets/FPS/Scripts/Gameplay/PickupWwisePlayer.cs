using UnityEngine;

public class PickupWwisePlayer : MonoBehaviour
{
    public AK.Wwise.Event launcherPickupEvent;

    public void PlayPickup(GameObject player)
    {
        if (launcherPickupEvent != null)
        {
            launcherPickupEvent.Post(player);
        }

    }

}
