using UnityEngine;

public class DoorBehavior : MonoBehaviour, Iinteractables
{
    public BoxCollider bc;
    public bool Interactiable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     bc = GetComponent<BoxCollider>(); 
    }

    public void Interact()
    {
        //method for manual opening the door
        if (Interactiable)
        {
            Debug.Log("Door has been opened");
            // play door opening sound
            bc.enabled = false;
        }
      

    }
    public void Enabled()
    {
        //event to open door
        bc.enabled = false;
        Debug.Log("Door has been opened");
        //door sounds
    }
}
