using UnityEngine;

public class ChestBehavior : MonoBehaviour, Iinteractables
{
    public BoxCollider bc;
    public AK.Wwise.Event drinkEvent;
    public AK.Wwise.Event cauldronStart;
    public AK.Wwise.Event cauldronStop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        cauldronStart.Post(gameObject);
    }
    public void Interact()
    {
        if (Haptics.instance != null)
            Haptics.instance.PulseHaptics(0.50f, 0.50f, 0.5f);
        Debug.Log("Potion has been Drunk");
        drinkEvent.Post(PlayerBehavior.instance.gameObject);
        cauldronStop.Post(gameObject);
        bc.enabled = false;
    // do the potion drinking 
     PlayerBehavior.instance.health = 100;
        PlayerBehavior.instance.healthRTPC.SetValue(PlayerBehavior.instance.gameObject, PlayerBehavior.instance.health);
       Debug.Log("Player new health is" +PlayerBehavior.instance.health);
    }
}
