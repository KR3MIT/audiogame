using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public LayerMask wallLayer;
    public float soundOffset = 3f;
    public PlayerMovement playerMovement;

    public AK.Wwise.Event playerCollisionEvent;
    public AK.Wwise.Event stopRubEvent;

    public GameObject soundObject;

    private GameObject soundObjectInstance;
    
    public List<GameObject> touchingWalls = new List<GameObject>();
    
    private void Start()
    {
        soundObjectInstance = Instantiate(soundObject, transform);
        Invoke(nameof(LateStart), 0);
    }

    private void LateStart()
    {
        if (!PlayerBehavior.WwiseActive)
        {
            gameObject.SetActive(false);
        }
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
            var direction = (hitPosition - transform.position).normalized;
            var newPosition = hitPosition + direction * soundOffset;

            soundObjectInstance.transform.position = newPosition;

            playerMovement.playerSpeedRTPC.SetValue(soundObjectInstance, PlayerMovement.NormalizedSpeed);
            playerCollisionEvent.Post(soundObjectInstance);
            
            Haptics.instance.SetMotorSpeeds(0.25f,0.25f);
            Haptics.instance.ResumeHaptics();
            
            if (!touchingWalls.Contains(other.gameObject))
            {
                touchingWalls.Add(other.gameObject);
            }
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            if (soundObjectInstance != null)
            {
                var hitPosition = other.GetContact(0).point;
                var direction = (hitPosition - transform.position).normalized;
                var newPosition = hitPosition + direction * soundOffset;

                soundObjectInstance.transform.position = newPosition;
                playerMovement.playerSpeedRTPC.SetValue(soundObjectInstance, PlayerMovement.NormalizedSpeed);
            }
            
            if (!touchingWalls.Contains(other.gameObject))
            {
                touchingWalls.Add(other.gameObject);
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        Haptics.instance.PauseHaptics();
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            touchingWalls.Remove(other.gameObject);

            if (touchingWalls.Count == 0)
            {
                playerMovement.playerSpeedRTPC.SetValue(soundObjectInstance, 0);
                stopRubEvent.Post(soundObjectInstance);
            }
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