using Unity.FPS.Game;
using UnityEngine;

public class Enemy_HoverBot_Shoot : MonoBehaviour
{
    public AK.Wwise.Event shootEvent;
    bool didFire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (didFire == true)
        {
            shootEvent.Post(gameObject);
        }
    }
}