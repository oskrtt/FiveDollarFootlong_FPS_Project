public class WwiseTypesExample : UnityEngine.MonoBehaviour
{
    public AK.Wwise.Bank MyBank = null;
    public AK.Wwise.Event MyEvent = null;
    public AK.Wwise.RTPC MyRTPC = null;
 
    public void Awake()
    {
        MyBank.Load();
    }
 
    public void Start()
    {
        MyEvent.Post(gameObject);
    }
 
    private float CalculateMyValue()
    {
        return (float)System.Math.Sin(System.Math.PI * UnityEngine.Time.timeSinceLevelLoad);
    }
 
    public void Update()
    {
        MyRTPC.SetValue(gameObject, CalculateMyValue());
    }
}