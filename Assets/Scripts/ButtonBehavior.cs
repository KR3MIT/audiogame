using UnityEngine;
using UnityEngine.Events;

public class ButtonBehavior : MonoBehaviour, Iinteractables
{
    public DoorBehavior door;
    public AK.Wwise.Event buttonGlowSound;
    public AK.Wwise.Event buttonPressSound;
    public float buttonAttenuationScaling;
    private bool buttonHasBeenPressed = false;
    private AkGameObj akGameObject;

    public UnityEvent buttonPressedEvent;

    void Start()
    {
        akGameObject = GetComponent<AkGameObj>();
        if (akGameObject != null)
        {
            akGameObject.ScalingFactor = buttonAttenuationScaling;
        }

        buttonGlowSound.Post(gameObject);
    }

    public void Interact()
    {
        if (!buttonHasBeenPressed)
        {
            buttonPressSound.Post(gameObject);
            Debug.Log("Button has been pressed");
            buttonHasBeenPressed = true;
            buttonPressedEvent?.Invoke();

            if (door)
            {
                door.Enabled();
            }

        }
    }
}
