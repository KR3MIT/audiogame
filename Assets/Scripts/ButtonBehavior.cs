using UnityEngine;

public class ButtonBehavior : MonoBehaviour, Iinteractables
{
    public DoorBehavior door;
    
    public void Interact()
    {
        // play button sound
        Debug.Log("Button has been pressed");
        door.Enabled();
    }
}
