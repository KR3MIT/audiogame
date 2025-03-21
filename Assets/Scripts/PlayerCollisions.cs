using System;
using System.Collections.Generic;
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
    
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("Player hit a wall!");

            if (soundObjectInstance != null)
            {
                stopRubEvent.Post(other.gameObject);
                Destroy(soundObjectInstance, 2f);
                soundObjectInstance = null;
            }
            
            var hitPosition = other.GetContact(0).point;
            soundObjectInstance = Instantiate(soundObject, hitPosition, Quaternion.identity); 
            
            playerCollisionEvent.Post(soundObjectInstance);
            
            //play Wall collision sound with Wwise ;) 
            
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            if(soundObjectInstance != null)
                soundObjectInstance.transform.position = other.contacts[0].point;
        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            stopRubEvent.Post(soundObjectInstance);
            Destroy(soundObjectInstance, 2f);
            soundObjectInstance = null;
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
