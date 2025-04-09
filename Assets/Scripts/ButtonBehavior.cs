using UnityEngine;

public class ButtonBehavior : MonoBehaviour, Iinteractables
{
    public DoorBehavior door;
    public AK.Wwise.Event buttonGlowSound;
    public AK.Wwise.Event buttonPressSound;
    public float buttonAttentuationScaling;

    void Start()
    {
        GetComponent<AkGameObj>().ScalingFactor = buttonAttentuationScaling;

        buttonGlowSound.Post(gameObject);
    }

    public void Interact()
    {
        buttonPressSound.Post(gameObject);
        Debug.Log("Button has been pressed");
        door.Enabled();
    }
}
