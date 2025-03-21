using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public LayerMask wallLayer;
    private float radius = 0.5f;
    private float offset = 0.1f;
    public PlayerMovement playerMovement;

    public AK.Wwise.Event playerCollisionEvent;
    public AK.Wwise.Event stopRubEvent;

    public GameObject soundObject;

    private GameObject soundObjectInstance;

    private List<GameObject> soundObjects = new List<GameObject>();

    
    private void Start()
    {
        soundObjectInstance = Instantiate(soundObject, transform);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            stopRubEvent.Post(soundObjectInstance);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("Player hit a wall!");

            var hitPosition = other.GetContact(0).point;
            soundObjectInstance.transform.position = hitPosition;

            playerMovement.playerSpeedRTPC.SetValue(soundObjectInstance, PlayerMovement.normalizedSpeed);
            playerCollisionEvent.Post(soundObjectInstance);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            if (soundObjectInstance != null)
            {
                playerMovement.playerSpeedRTPC.SetValue(soundObjectInstance, PlayerMovement.normalizedSpeed);
                soundObjectInstance.transform.position = other.contacts[0].point;
            }
        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            playerMovement.playerSpeedRTPC.SetValue(soundObjectInstance, 0);
            stopRubEvent.Post(soundObjectInstance);
        }
    }


    //oldig

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
    //     {
    //         Debug.Log("Player hit a wall!");
    //         playerCollisionEvent.Post(transform.root.gameObject);
    //         
    //         
    //         
    //         //play Wall collision sound with Wwise ;) 
    //         
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
    //     {
    //         stopRubEvent.Post(transform.root.gameObject);
    //         
    //     }
    // }
}