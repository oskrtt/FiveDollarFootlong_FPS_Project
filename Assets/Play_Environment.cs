using UnityEngine;

public class Play_Environment : MonoBehaviour
{
    public AK.Wwise.Event environmentEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        environmentEvent.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
