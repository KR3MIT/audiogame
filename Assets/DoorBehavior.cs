using UnityEngine;

public class DoorBehavior : MonoBehaviour, Iinteractables
{
    public BoxCollider bc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     bc = GetComponent<BoxCollider>(); 
    }

    public void Interact()
    {
        Debug.Log("Door has been opened");
        // play door opening sound
        bc.enabled = false;
    }
}
