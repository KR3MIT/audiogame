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
    }
    private void Update()
    {
        if (input.actions["Interact"].triggered)
        {
            PlayerInteraction();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            SetCheckpoint(other.transform.position);
        }
    }
    public void SetCheckpoint(Vector3 pos)
    {
        //PLAY CHECKPOINT SOUND
        checkpoint = pos;
        //a checkpoint has been checked, play sound
        Haptics.instance.PulseHaptics(0.25f,0.25f, 0.1f);
    }
    public void TakeDamage(int damage)
    {
        Haptics.instance.PulseHaptics(0.75f,0.75f, 0.2f);
        //PLAY DAMAGE NOISE
        health -= damage;
        Debug.Log("Player took "+ damage +" damage. Health is now: " + health);
        if (health <= 0)
            StartCoroutine(Death());
        
    }
   public  IEnumerator Death()
    {
        //PLAY DEATH SOUND
        controller.enabled = false;
        Debug.Log("A respawn has been respawned");
        transform.position = checkpoint;
        yield return new WaitForSeconds(respawnTime);
        //play REVIVE SOUND
        health = 100;
        controller.enabled = true;
    }

    void PlayerInteraction()
    {
        if(Physics.BoxCast(transform.position, Vector3.zero, transform.forward, out RaycastHit hit, transform.rotation, 2f))
        {
            if(hit.collider.gameObject.GetComponent<Iinteractables>() != null)
            {
                hit.collider.gameObject.GetComponent<Iinteractables>().Interact();
                //PLAY INTERACTION SOUND
                Haptics.instance.PulseHaptics(0.25f,0.25f, 0.1f);
            }
        }
    }
}
