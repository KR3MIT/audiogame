using System;
using UnityEngine;
using AK;

public class Footstepper : MonoBehaviour
{
    public AK.Wwise.Event footstepEvent;

    public void Start()
    {
        PlayerSounds.FootstepEvent += PlaySound;
    }

    public void PlaySound()
    {
        footstepEvent.Post(gameObject);
    }
}
