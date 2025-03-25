using UnityEngine;

public class ChestBehavior : MonoBehaviour, Iinteractables
{
    public BoxCollider bc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bc = GetComponent<BoxCollider>();
    }
    public void Interact()
    {
        Debug.Log("Potion has been Drunk");
        bc.enabled = false;
    // do the potion drinking 
     PlayerBehavior.instance.health = 100;
       Debug.Log("Player new health is" +PlayerBehavior.instance.health);
    }
}
