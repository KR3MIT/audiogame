using UnityEngine;

public class ChestBehavior : MonoBehaviour, Iinteractables
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void Interact()
    {
        Debug.Log("Chest has been opened");
    // do the chest opening sound
    // and reward player something idk yet
    }
}
