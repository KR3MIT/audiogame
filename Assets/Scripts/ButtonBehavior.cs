using UnityEngine;

public class ButtonBehavior : MonoBehaviour, Iinteractables
{
    public DoorBehavior door;
    public AK.Wwise.Event buttonGlowSound;
    public AK.Wwise.Event buttonPressSound;
    public float buttonAttentuationScaling;
    private bool buttonHasBeenPressed = false;

    void Start()
    {
        GetComponent<AkGameObj>().ScalingFactor = buttonAttentuationScaling;

        buttonGlowSound.Post(gameObject);
    }

    public void Interact()
    {
        if (!buttonHasBeenPressed)
        {
            buttonPressSound.Post(gameObject);
            Debug.Log("Button has been pressed");
            buttonHasBeenPressed = true;
            door.Enabled();
        }
    }
}
