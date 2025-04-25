using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehavior : MonoBehaviour
{
    public int health = 100;
    public float respawnTime;
    
    [HideInInspector]public Vector3 checkpoint;
    
    public static bool WwiseActive { get; private set; }
    public static PlayerBehavior instance;

    private CharacterController controller;
    private PlayerInput input;

    public AK.Wwise.Event takeDamageEvent;
    public AK.Wwise.Event playerDeathEvent;
    public AK.Wwise.Event playerReviveEvent;
    public AK.Wwise.Event checkpointEvent;

    public AK.Wwise.Event heartbeatEvent;
    public AK.Wwise.RTPC healthRTPC;
    public AK.Wwise.RTPC playerHitTimeRTPC;

    private Coroutine takeDamgeTimeCoroutine;

    public float val;
   
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

     
    }
    void Start()
    {
        input = GetComponent<PlayerInput>();
        WwiseActive = GameObject.Find("WwiseGlobal") != null;
        
        controller = GetComponent<CharacterController>();
        checkpoint = transform.position;

        if (WwiseActive)
        {
            heartbeatEvent.Post(gameObject);
            healthRTPC.SetValue(gameObject, health);
            playerHitTimeRTPC.SetValue(gameObject, 0);
        }
    }
    private void Update()
    {
        if (input.actions["Interact"].triggered)
        {
            PlayerInteraction();
            Debug   .Log("Interact button pressed");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    public void SetCheckpoint(Vector3 pos)
    {
        checkpointEvent.Post(gameObject);
        checkpoint = pos;
        ApplyHaptics(0.25f, 0.25f, 0.1f);
    }
    public void TakeDamage(int damage)
    {
        ApplyHaptics(0.75f, 0.75f, 0.2f);
        takeDamageEvent.Post(gameObject);
        health -= damage;

        healthRTPC.SetValue(gameObject, health);

        if(takeDamgeTimeCoroutine != null)
        {
            StopCoroutine(takeDamgeTimeCoroutine);
            takeDamgeTimeCoroutine = null;
        }
        takeDamgeTimeCoroutine = StartCoroutine(TakeDamageSoundWindDown());

        Debug.Log("Player took "+ damage +" damage. Health is now: " + health);
        if (health <= 0)
            StartCoroutine(Death());
        
    }

    public IEnumerator TakeDamageSoundWindDown()
    {
         val = 1;

        while (val > 0)
        {
            val -= .0025f;
            playerHitTimeRTPC.SetValue(gameObject, val);
            yield return new WaitForSeconds(0.01f);
        }
    }
    
   public  IEnumerator Death()
    {
        playerDeathEvent.Post(gameObject);
        controller.enabled = false;
        Debug.Log("A respawn has been respawned");
        transform.position = checkpoint;
        yield return new WaitForSeconds(respawnTime);
        playerReviveEvent.Post(gameObject);
        health = 100;
        instance.healthRTPC.SetValue(instance.gameObject,instance.health);
        controller.enabled = true;
    }

    void PlayerInteraction()
    {
        var sphereCast = Physics.OverlapSphere(transform.position, 3f, LayerMask.GetMask("InteractableLayer"));
    
        foreach (var hit in sphereCast)
        { 
           
            if(hit.gameObject.GetComponent<Iinteractables>() != null)
            {
               
                hit.gameObject.GetComponent<Iinteractables>().Interact();
                //PLAY INTERACTION SOUND
                ApplyHaptics(0.25f, 0.25f, 0.1f);
                return;
            }
        }
    }

    void ApplyHaptics(float lowFreq, float highFreq, float duration)
    {
        if (Haptics.instance != null)
            Haptics.instance.PulseHaptics(lowFreq, highFreq, duration);
    }
}
