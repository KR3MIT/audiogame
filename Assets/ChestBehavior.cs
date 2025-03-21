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
        Debug.Log("Chest has been opened");
    // do the chest opening sound
    // and reward player something idk yet
    }
}
